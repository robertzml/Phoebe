using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoebe.Model;

namespace Phoebe.Business
{
    /// <summary>
    /// 统计业务
    /// </summary>
    public class StatisticBusiness
    {
        #region Field
        private PhoebeContext context;
        #endregion //Field

        #region Constructor
        public StatisticBusiness()
        {
            this.context = new PhoebeContext();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 获取日入库
        /// </summary>
        /// <param name="date">日期</param>
        /// <returns></returns>
        public List<StockFlow> GetDailyFlowIn(DateTime date)
        {
            List<StockFlow> data = new List<StockFlow>();

            var stockIns = this.context.StockIns.Where(r => r.InTime == date && r.Status == (int)EntityStatus.StockIn);

            foreach(var si in stockIns)
            {
                Contract contract = si.Contract;

                foreach(var item in si.StockInDetails)
                {
                    Cargo cargo = item.Cargo;

                    StockFlow flow = new StockFlow();
                    flow.CustomerID = contract.CustomerID;
                    flow.CustomerName = contract.Customer.Name;
                    flow.ContractID = contract.ID;
                    flow.ContractName = contract.Name;
                    flow.CargoID = cargo.ID;
                    flow.CargoName = cargo.Name;
                    flow.FirstCategoryID = cargo.FirstCategoryID;
                    flow.FirstCategoryName = cargo.FirstCategory.Name;
                    flow.SecondCategoryID = cargo.SecondCategoryID;
                    flow.SecondCategoryName = cargo.SecondCategory.Name;

                    if (cargo.ThirdCategoryID == null)
                    {
                        flow.ThirdCategoryID = 0;
                        flow.ThirdCategoryName = "";
                    }
                    else
                    {
                        flow.ThirdCategoryID = cargo.ThirdCategoryID.Value;
                        flow.ThirdCategoryName = cargo.ThirdCategory.Name;
                    }

                    flow.Count = item.Count;
                    flow.UnitWeight = cargo.UnitWeight;
                    flow.Weight = flow.Count * flow.UnitWeight / 1000;
                    flow.FlowDate = date;
                    flow.Type = StockFlowType.StockIn;

                    data.Add(flow);
                }
            }

            return data;
        }

        /// <summary>
        /// 获取日出库
        /// </summary>
        /// <param name="date">日期</param>
        /// <returns></returns>
        public List<StockFlow> GetDailyFlowOut(DateTime date)
        {
            List<StockFlow> data = new List<StockFlow>();

            var stockOuts = this.context.StockOuts.Where(r => r.OutTime == date && r.Status == (int)EntityStatus.StockOut);

            foreach (var so in stockOuts)
            {
                Contract contract = so.Contract;

                foreach (var item in so.StockOutDetails)
                {
                    Cargo cargo = item.Cargo;

                    StockFlow flow = new StockFlow();
                    flow.CustomerID = contract.CustomerID;
                    flow.CustomerName = contract.Customer.Name;
                    flow.ContractID = contract.ID;
                    flow.ContractName = contract.Name;
                    flow.CargoID = cargo.ID;
                    flow.CargoName = cargo.Name;
                    flow.FirstCategoryID = cargo.FirstCategoryID;
                    flow.FirstCategoryName = cargo.FirstCategory.Name;
                    flow.SecondCategoryID = cargo.SecondCategoryID;
                    flow.SecondCategoryName = cargo.SecondCategory.Name;

                    if (cargo.ThirdCategoryID == null)
                    {
                        flow.ThirdCategoryID = 0;
                        flow.ThirdCategoryName = "";
                    }
                    else
                    {
                        flow.ThirdCategoryID = cargo.ThirdCategoryID.Value;
                        flow.ThirdCategoryName = cargo.ThirdCategory.Name;
                    }

                    flow.Count = item.Count;
                    flow.UnitWeight = cargo.UnitWeight;
                    flow.Weight = flow.Count * flow.UnitWeight / 1000;
                    flow.FlowDate = date;
                    flow.Type = StockFlowType.StockOut;

                    data.Add(flow);
                }
            }

            return data;
        }
        #endregion //Method
    }
}
