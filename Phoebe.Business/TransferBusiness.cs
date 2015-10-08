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

        public ErrorCode Audit(string id, DateTime confirmTime)
        {
            try
            {
                // change stock
                //foreach (var item in details)
                //{
                //    var store = stocks.Single(r => r.WarehouseID == item.WarehouseID);
                //    store.CargoID = newCargo.ID;
                //}
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
