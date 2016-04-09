using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoebe.Model;

namespace Phoebe.Business
{
    /// <summary>
    /// 合同业务类
    /// </summary>
    public class ContractBusiness
    {
        #region Field
        private PhoebeContext context;
        #endregion //Field

        #region Constructor
        public ContractBusiness()
        {
            this.context = new PhoebeContext();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 获取所有合同
        /// </summary>
        /// <returns></returns>
        public List<Contract> Get()
        {
            return this.context.Contracts.OrderByDescending(r => r.SignDate).ToList();
        }

        /// <summary>
        /// 获取合同
        /// </summary>
        /// <param name="id">合同ID</param>
        /// <returns></returns>
        public Contract Get(int id)
        {
            return this.context.Contracts.Find(id);
        }

        /// <summary>
        /// 获取当前正常合同
        /// </summary>
        /// <returns></returns>
        public List<Contract> GetNormal()
        {
            return this.context.Contracts.Where(r => r.Status == 0).OrderByDescending(r => r.SignDate).ToList();
        }

        /// <summary>
        /// 根据类型获取合同
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public List<Contract> GetByType(EntityStatus status)
        {
            return this.context.Contracts.Where(r => r.Status == (int)status).OrderByDescending(r => r.SignDate).ToList();
        }

        /// <summary>
        /// 获取相关合同
        /// </summary>
        /// <param name="customerID">客户ID</param>
        /// <param name="customerType">客户类型</param>
        /// <returns></returns>
        public List<Contract> GetByCustomer(int customerID)
        {
            return this.context.Contracts.Where(r => r.CustomerID == customerID).ToList();
        }

        /// <summary>
        /// 获取未入库货品相关合同
        /// </summary>
        /// <returns></returns>
        //public List<Contract> GetWithUnStockIn()
        //{
        //    var contracts = from r in this.context.Contracts
        //                    where (from s in this.context.Cargoes
        //                           where s.Status == (int)EntityStatus.CargoNotIn
        //                           group s by s.ContractID into g
        //                           select g.Key).Contains(r.ID)
        //                    select r;

        //    return contracts.ToList();
        //}

        /// <summary>
        /// 获取有库存合同
        /// </summary>
        /// <returns></returns>
        //public List<Contract> GetWithHasStock()
        //{
        //    var contracts = from r in this.context.Contracts
        //                    where (from s in this.context.Cargoes
        //                           where s.Status == (int)EntityStatus.CargoStockIn
        //                           group s by s.ContractID into g
        //                           select g.Key).Contains(r.ID)
        //                    select r;

        //    return contracts.ToList();
        //}

        /// <summary>
        /// 添加合同
        /// </summary>
        /// <param name="data">合同数据</param>
        /// <returns></returns>
        public ErrorCode Create(Contract data)
        {
            try
            {
                data.Status = 0;

                int count = this.context.Contracts.Count(r => r.Number == data.Number);
                if (count > 0)
                    return ErrorCode.ContractDuplicateNumber;

                this.context.Contracts.Add(data);
                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }

        /// <summary>
        /// 编辑合同
        /// </summary>
        /// <param name="data">合同数据</param>
        /// <returns></returns>
        public ErrorCode Edit(Contract data)
        {
            try
            {
                this.context.Entry(data).State = EntityState.Modified;
                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }

        /// <summary>
        /// 关闭合同
        /// </summary>
        /// <param name="id">合同ID</param>
        /// <returns></returns>
        public ErrorCode Close(int id)
        {
            try
            {
                var data = this.context.Contracts.Find(id);
                if (data == null)
                    return ErrorCode.ObjectNotFound;

                //if (data.Cargoes.Any(r => r.Status != (int)EntityStatus.CargoStockOut))
                //{
                //    return ErrorCode.ContractHasCargo;
                //}

                data.CloseDate = DateTime.Now;
                data.Status = (int)EntityStatus.ContractClosed;
                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }

        /// <summary>
        /// 删除合同
        /// </summary>
        /// <param name="data">合同对象</param>
        /// <returns></returns>
        public ErrorCode Delete(Contract data)
        {
            try
            {
                if (this.context.Cargoes.Count(r => r.ContractID == data.ID) > 0)
                {
                    return ErrorCode.ContractHasCargo;
                }

                this.context.Contracts.Remove(data);
                this.context.SaveChanges();

                return ErrorCode.Success;
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }
        }

        /// <summary>
        /// 强制删除合同
        /// </summary>
        /// <param name="data">合同对象</param>
        /// <returns></returns>
        public ErrorCode ForceDelete(Contract data)
        {
            try
            {
                int customerId = data.CustomerID;

                //delete the settlement                
                var settles = this.context.Settlements.Where(r => r.CustomerID == customerId);
                if (settles.Count() != 0)
                {
                    this.context.Settlements.RemoveRange(settles);
                }

                //delete the stock in
                var stockIns = this.context.StockIns.Where(r => r.ContractID == data.ID);
                if (stockIns.Count() != 0)
                {
                    this.context.StockIns.RemoveRange(stockIns);
                }

                //delete the stock out
                var stockOuts = this.context.StockOuts.Where(r => r.ContractID == data.ID);
                if (stockOuts.Count() != 0)
                {
                    this.context.StockOuts.RemoveRange(stockOuts);
                }

                //delete the stock move
                var stockMoves = this.context.StockMoves.Where(r => r.ContractID == data.ID);
                if (stockMoves.Count() != 0)
                {
                    this.context.StockMoves.RemoveRange(stockMoves);
                }
                this.context.SaveChanges();

                //delete the cargos
                var cargos = this.context.Cargoes.Where(r => r.ContractID == data.ID);
                if (cargos.Count() != 0)
                {
                    this.context.Cargoes.RemoveRange(cargos);
                }

                this.context.Contracts.Remove(data);
                this.context.SaveChanges();

                return ErrorCode.Success;
            }
            catch (Exception e)
            {
                return ErrorCode.Exception;
            }
        }
        #endregion //Method
    }
}
