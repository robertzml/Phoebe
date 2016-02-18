using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoebe.Model;

namespace Phoebe.Business
{
    /// <summary>
    /// 统计业务类
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

        #region Function
        /// <summary>
        /// 设置盘点期初数据
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="start">期初库存</param>
        /// <param name="endTime">期末时间</param>
        /// <param name="customerID">客户ID</param>
        /// <param name="customerName">客户名称</param>
        /// <returns></returns>
        private Inventory SetInventoryStart(List<Inventory> data, Storage start, DateTime endTime, int customerID, string customerName)
        {
            var inv = data.SingleOrDefault(r => r.CustomerID == customerID && r.FirstCategoryID == start.FirstCategoryID &&
                r.SecondCategoryID == start.SecondCategoryID && r.ThirdCategoryID == start.ThirdCategoryID);

            if (inv == null)
            {
                Inventory inventory = new Inventory();
                inventory.CustomerID = customerID;
                inventory.CustomerName = customerName;
                inventory.FirstCategoryID = start.FirstCategoryID;
                inventory.FirstCategoryName = start.FirstCategoryName;
                inventory.SecondCategoryID = start.SecondCategoryID;
                inventory.SecondCategoryName = start.SecondCategoryName;
                inventory.ThirdCategoryID = start.ThirdCategoryID;
                inventory.ThirdCategoryName = start.ThirdCategoryName;
                inventory.StartTime = start.StorageDate;
                inventory.StartCount = start.Count;
                inventory.StartWeight = start.Weight;
                inventory.EndTime = endTime;

                return inventory;
            }
            else
            {
                inv.StartCount += start.Count;
                inv.StartWeight += start.Weight;

                return null;
            }
        }

        /// <summary>
        /// 设置盘点期末数据
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="end">期末库存</param>
        /// <param name="StartTime">期初时间</param>
        /// <param name="customerID">客户ID</param>
        /// <param name="customerName">客户名称</param>
        public Inventory SetInventoryEnd(List<Inventory> data, Storage end, DateTime startTime, int customerID, string customerName)
        {
            var inv = data.SingleOrDefault(r => r.CustomerID == customerID && r.FirstCategoryID == end.FirstCategoryID &&
               r.SecondCategoryID == end.SecondCategoryID && r.ThirdCategoryID == end.ThirdCategoryID);

            if (inv == null)
            {
                Inventory inventory = new Inventory();
                inventory.CustomerID = customerID;
                inventory.CustomerName = customerName;
                inventory.FirstCategoryID = end.FirstCategoryID;
                inventory.FirstCategoryName = end.FirstCategoryName;
                inventory.SecondCategoryID = end.SecondCategoryID;
                inventory.SecondCategoryName = end.SecondCategoryName;
                inventory.ThirdCategoryID = end.ThirdCategoryID;
                inventory.ThirdCategoryName = end.ThirdCategoryName;
                inventory.StartTime = startTime;
                inventory.EndTime = end.StorageDate;
                inventory.EndCount = end.Count;
                inventory.EndWeight = end.Weight;

                return inventory;
            }
            else
            {
                inv.EndCount += end.Count;
                inv.EndWeight += end.Weight;

                return null;
            }
        }
        #endregion //Function

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

            foreach (var si in stockIns)
            {
                Contract contract = si.Contract;

                foreach (var item in si.StockInDetails)
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

        /// <summary>
        /// 获取入库记录
        /// </summary>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <param name="customerID">客户ID，0表示所有客户</param>
        /// <returns></returns>
        public List<StockFlow> GetFlowIn(DateTime start, DateTime end, int customerID)
        {
            List<StockFlow> data = new List<StockFlow>();

            IQueryable<StockIn> stockIns;
            if (customerID == 0)
                stockIns = this.context.StockIns.Where(r => r.InTime >= start && r.InTime <= end && r.Status == (int)EntityStatus.StockIn);
            else
            {
                stockIns = from r in this.context.StockIns
                           where r.InTime >= start && r.InTime <= end && r.Status == (int)EntityStatus.StockIn &&
                                (from s in this.context.Contracts
                                 where s.CustomerID == customerID
                                 select s.ID).Contains(r.ContractID)
                           select r;
            }

            foreach (var si in stockIns)
            {
                Contract contract = si.Contract;

                foreach (var item in si.StockInDetails)
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
                    flow.FlowDate = si.InTime;
                    flow.Type = StockFlowType.StockIn;

                    data.Add(flow);
                }
            }

            return data;
        }

        /// <summary>
        /// 获取出库记录
        /// </summary>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <param name="customerID">客户ID，0表示所有客户</param>
        /// <returns></returns>
        public List<StockFlow> GetFlowOut(DateTime start, DateTime end, int customerID)
        {
            List<StockFlow> data = new List<StockFlow>();

            IQueryable<StockOut> stockOuts;
            if (customerID == 0)
                stockOuts = this.context.StockOuts.Where(r => r.OutTime >= start && r.OutTime <= end && r.Status == (int)EntityStatus.StockOut);
            else
            {
                stockOuts = from r in this.context.StockOuts
                            where r.OutTime >= start && r.OutTime <= end && r.Status == (int)EntityStatus.StockOut &&
                                (from s in this.context.Contracts
                                 where s.CustomerID == customerID
                                 select s.ID).Contains(r.ContractID)
                            select r;
            }

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
                    flow.FlowDate = so.OutTime;
                    flow.Type = StockFlowType.StockOut;

                    data.Add(flow);
                }
            }

            return data;
        }

        /// <summary>
        /// 获取库存盘点
        /// </summary>
        /// <param name="startTime">开始日期</param>
        /// <param name="endTime">结束日期</param>
        /// <param name="customerID">客户ID</param>
        /// <returns></returns>
        public List<Inventory> GetInventory(DateTime startTime, DateTime endTime, int customerID)
        {
            List<Inventory> data = new List<Inventory>();

            StoreBusiness storeBusiness = new StoreBusiness();

            var customer = this.context.Customers.Find(customerID);
            var contracts = this.context.Contracts.Where(r => r.CustomerID == customer.ID);

            foreach (var contract in contracts)
            {
                var startStorages = storeBusiness.GetInDay(contract.ID, startTime);
                var endStorages = storeBusiness.GetInDay(contract.ID, endTime);

                foreach (var storage in startStorages)
                {
                    var inv = SetInventoryStart(data, storage, endTime, customer.ID, customer.Name);
                    if (inv != null)
                    {
                        data.Add(inv);
                    }
                }

                foreach (var storage in endStorages)
                {
                    var inv = SetInventoryEnd(data, storage, startTime, customer.ID, customer.Name);
                    if (inv != null)
                    {
                        data.Add(inv);
                    }
                }
            }

            return data;
        }
        #endregion //Method
    }
}
