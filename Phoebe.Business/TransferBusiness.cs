using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoebe.Model;

namespace Phoebe.Business
{
    /// <summary>
    /// 转户业务类
    /// </summary>
    public class TransferBusiness
    {
        #region Field
        private PhoebeContext context;
        #endregion //Field

        #region Constructor
        public TransferBusiness()
        {
            this.context = new PhoebeContext();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 获取转户记录
        /// </summary>
        /// <returns></returns>
        public List<Transfer> Get()
        {
            return this.context.Transfers.OrderByDescending(r => r.ConfirmTime).ToList();
        }

        /// <summary>
        /// 获取转户记录
        /// </summary>
        /// <param name="id">转户ID</param>
        /// <returns></returns>
        public Transfer Get(string id)
        {
            Guid gid;
            if (!Guid.TryParse(id, out gid))
                return null;

            return this.context.Transfers.Find(gid);
        }

        /// <summary>
        /// 获取转户记录
        /// </summary>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public List<Transfer> Get(EntityStatus status)
        {
            return this.context.Transfers.Where(r => r.Status == (int)status).ToList();
        }

        /// <summary>
        /// 获取转户详细信息
        /// </summary>
        /// <param name="cargoID">货品ID</param>
        /// <param name="transOut">转出或转入</param>
        /// <returns></returns>
        public List<TransferDetail> GetDetailsByCargo(string cargoID, bool transOut)
        {
            Guid gid;
            if (!Guid.TryParse(cargoID, out gid))
                return null;

            if (transOut)
            {
                var data = from r in this.context.TransferDetails
                           where this.context.Transfers.Where(s => s.OldCargoID == gid).Select(s => s.ID).Contains(r.TransferID)
                           select r;

                return data.ToList();
            }
            else
            {
                var data = from r in this.context.TransferDetails
                           where this.context.Transfers.Where(s => s.NewCargoID == gid).Select(s => s.ID).Contains(r.TransferID)
                           select r;

                return data.ToList();
            }
        }

        /// <summary>
        /// 根据库存获取转户记录
        /// </summary>
        /// <param name="stockID">库存ID</param>
        /// <returns></returns>
        public List<TransferDetail> GetByStore(string stockID)
        {
            Guid gid;
            if (!Guid.TryParse(stockID, out gid))
                return null;

            return this.context.TransferDetails.Where(r => r.StockID == gid).ToList();
        }

        /// <summary>
        /// 货品转户
        /// </summary>
        /// <param name="data">转户数据</param>
        /// <param name="details">详细数据</param>
        /// <param name="newContractID">新合同ID</param>
        /// <returns></returns>
        public ErrorCode Transfer(Transfer data, List<TransferDetail> details, int newContractID)
        {
            try
            {
                // find store first
                var stocks = this.context.Stocks.Where(r => r.CargoID == data.OldCargoID && r.Status == (int)EntityStatus.StoreIn);
                if (stocks.Count() == 0)
                    return ErrorCode.StockNotFound;

                // set count
                foreach (var item in details)
                {
                    item.Count = stocks.Single(r => r.WarehouseID == item.WarehouseID).Count;
                }
                int totalCount = details.Sum(r => r.Count);

                Cargo oldCargo = this.context.Cargoes.Find(data.OldCargoID);

                // add new cargo
                Cargo newCargo = new Cargo
                {
                    ID = Guid.NewGuid(),
                    Name = oldCargo.Name,
                    FirstCategoryID = oldCargo.FirstCategoryID,
                    SecondCategoryID = oldCargo.SecondCategoryID,
                    ThirdCategoryID = oldCargo.ThirdCategoryID,
                    Count = totalCount,
                    UnitWeight = oldCargo.UnitWeight,
                    TotalWeight = Math.Round(Convert.ToDouble(totalCount * oldCargo.UnitWeight / 1000), 3),
                    UnitVolume = oldCargo.UnitVolume,
                    TotalVolume = Math.Round(Convert.ToDouble(totalCount * oldCargo.UnitVolume), 3),
                    StoreCount = totalCount,
                    OriginPlace = oldCargo.OriginPlace,
                    Specification = oldCargo.Specification,
                    ShelfLife = oldCargo.ShelfLife,
                    ContractID = newContractID,
                    RegisterTime = oldCargo.RegisterTime,
                    UserID = data.UserID,
                    InTime = oldCargo.InTime,
                    Remark = oldCargo.Remark,
                    Status = (int)EntityStatus.CargoTransferReady
                };

                this.context.Cargoes.Add(newCargo);

                // add transfer
                data.ID = Guid.NewGuid();
                data.NewCargoID = newCargo.ID;
                data.Status = (int)EntityStatus.TransferReady;

                this.context.Transfers.Add(data);

                // add transfer detail
                foreach (var item in details)
                {
                    // get store
                    var s = stocks.SingleOrDefault(r => r.WarehouseID == item.WarehouseID);
                    if (s == null)
                        return ErrorCode.StockNotFound;

                    item.ID = Guid.NewGuid();
                    item.WarehouseID = s.WarehouseID;
                    item.StockID = s.ID;
                    item.Status = (int)EntityStatus.TransferReady;
                    item.TransferID = data.ID;

                    this.context.TransferDetails.Add(item);
                }

                this.context.SaveChanges();

            }
            catch (Exception e)
            {
                string m = e.Message;
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }

        /// <summary>
        /// 转户审核
        /// </summary>
        /// <param name="id">转户ID</param>
        /// <param name="confirmTime">确认时间</param>
        /// <param name="remark">备注</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public ErrorCode Audit(string id, DateTime confirmTime, string remark, EntityStatus status)
        {
            try
            {
                Guid gid;
                if (!Guid.TryParse(id, out gid))
                    return ErrorCode.ObjectNotFound;

                Transfer trans = this.context.Transfers.Find(gid);
                if (trans == null)
                    return ErrorCode.ObjectNotFound;

                trans.ConfirmTime = confirmTime;
                trans.Remark = remark;
                trans.Status = (int)status;

                if (status == EntityStatus.Transfer)
                {
                    Cargo oldCargo = trans.OldCargo;

                    foreach (var item in trans.TransferDetails)
                    {
                        // change transfer details
                        item.Status = (int)EntityStatus.Transfer;

                        // change stock
                        var stock = item.Stock;
                        if (stock == null)
                            return ErrorCode.StockNotFound;

                        stock.CargoID = trans.NewCargoID;
                    }

                    // change new cargo
                    Cargo newCargo = trans.NewCargo;
                    newCargo.Status = (int)EntityStatus.CargoStockIn;

                    // add new cargo billing
                    newCargo.Billing = new Billing();
                    newCargo.Billing.CargoID = newCargo.ID;
                    newCargo.Billing.BillingType = oldCargo.Billing.BillingType;
                    newCargo.Billing.UnitPrice = oldCargo.Billing.UnitPrice;
                    newCargo.Billing.IsTiming = oldCargo.Billing.IsTiming;
                    newCargo.Billing.HandlingPrice = oldCargo.Billing.HandlingPrice;
                    newCargo.Billing.FreezePrice = oldCargo.Billing.FreezePrice;
                    newCargo.Billing.DisposePrice = oldCargo.Billing.DisposePrice;
                    newCargo.Billing.PackingPrice = oldCargo.Billing.PackingPrice;
                    newCargo.Billing.RentPrice = oldCargo.Billing.RentPrice;
                    newCargo.Billing.OtherPrice = oldCargo.Billing.OtherPrice;
                    newCargo.Billing.Remark = oldCargo.Billing.Remark;
                    newCargo.Billing.Status = oldCargo.Billing.Status;

                    // check old cargo
                    int transCount = trans.TransferDetails.Sum(r => r.Count);
                    oldCargo.StoreCount -= transCount;
                    if (oldCargo.StoreCount == 0)
                    {
                        oldCargo.Status = (int)EntityStatus.CargoHasTransfer;
                        oldCargo.OutTime = trans.ConfirmTime;
                    }
                }
                else
                {
                    //change transfer details status
                    foreach (var item in trans.TransferDetails)
                    {
                        item.Status = (int)EntityStatus.TransferCancel;
                    }

                    // change new cargo status
                    trans.NewCargo.Status = (int)EntityStatus.CargoTransferCancel;
                }

                this.context.SaveChanges();

            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }
        #endregion //Method
    }
}
