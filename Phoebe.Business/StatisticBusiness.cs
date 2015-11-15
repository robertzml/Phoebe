﻿using System;
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

        #region Method
        /// <summary>
        /// 按客户获取流水
        /// </summary>
        /// <param name="customerType">客户类型</param>
        /// <param name="customerID">客户ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        public List<StockFlow> GetFlowByCustomer(int customerType, int customerID, DateTime start, DateTime end)
        {
            List<StockFlow> data = new List<StockFlow>();
            var contracts = this.context.Contracts.Where(r => r.CustomerType == customerType && r.CustomerID == customerID);

            StoreBusiness storeBusiness = new StoreBusiness();
            foreach (var contract in contracts)
            {
                for (DateTime step = start; step <= end; step = step.AddDays(1))
                {
                    var flows = storeBusiness.GetDaysFlow(contract.ID, step);
                    data.AddRange(flows);
                }
            }

            return data;
        }

        /// <summary>
        /// 按客户获取库存
        /// </summary>
        /// <param name="customerType">客户类型</param>
        /// <param name="customerID">客户ID</param>
        /// <param name="date">日期</param>
        /// <returns></returns>
        public List<Storage> GetStoreByCustomer(int customerType, int customerID, DateTime date)
        {
            List<Storage> data = new List<Storage>();
            var contracts = this.context.Contracts.Where(r => r.CustomerType == customerType && r.CustomerID == customerID);

            StoreBusiness storeBusiness = new StoreBusiness();
            foreach (var contract in contracts)
            {
                var store = storeBusiness.GetInDay(contract.ID, date);
                data.AddRange(store);
            }

            return data;
        }

        /// <summary>
        /// 按客户获取分类库存
        /// </summary>
        /// <param name="customerType">客户类型</param>
        /// <param name="customerID">客户ID</param>
        /// <returns></returns>
        public StoreClassifyModel GetClassifyStoreByCustomer(int customerType, int customerID)
        {
            var cargos = from r in this.context.Cargoes
                         where r.Status != (int)EntityStatus.CargoNotIn && r.Status != (int)EntityStatus.CargoStockInReady && r.StoreCount != 0 &&
                            (from s in this.context.Contracts
                             where s.CustomerID == customerID && s.CustomerType == customerType
                             select s.ID).Contains(r.ContractID)
                         select r;

            List<StoreClassifyPlanModel> plans = new List<StoreClassifyPlanModel>();
            foreach (var item in cargos)
            {
                string number = string.Format("{0}-{1}-{2}", item.FirstCategoryID, item.SecondCategoryID, item.ThirdCategoryID == null ? 0 : item.ThirdCategoryID);

                if (plans.Any(r => r.CategoryNumber == number))
                {
                    var model = plans.Single(r => r.CategoryNumber == number);
                    model.StoreCount += item.StoreCount;
                    model.Weight += model.StoreCount * item.UnitWeight / 1000;
                }
                else
                {
                    StoreClassifyPlanModel model = new StoreClassifyPlanModel
                    {
                        CustomerID = customerID,
                        CustomerType = customerType,
                        CategoryNumber = number,
                        FirstCategoryID = item.FirstCategoryID,
                        FirstCategoryName = item.FirstCategory.Name,
                        SecondCategoryID = item.SecondCategoryID,
                        SecondCategoryName = item.SecondCategory.Name,
                        ThirdCategoryID = item.ThirdCategoryID == null ? 0 : item.ThirdCategoryID.Value,
                        ThirdCategoryName = item.ThirdCategory == null ? "" : item.ThirdCategory.Name,
                        StoreCount = item.StoreCount,
                        Weight = item.StoreCount * item.UnitWeight / 1000
                    };

                    plans.Add(model);
                }
            }

            StoreClassifyModel data = new StoreClassifyModel();
            data.CustomerID = customerID;
            data.CustomerType = customerType;
            data.FirstStore = new List<StoreFirstCategory>();

            foreach (var firstId in plans.Select(r => r.FirstCategoryID).Distinct())
            {
                StoreFirstCategory first = new StoreFirstCategory();
                first.FirstCategoryID = firstId;
                first.FirstCategoryName = plans.First(r => r.FirstCategoryID == firstId).FirstCategoryName;
                first.SecondStore = new List<StoreSecondCategory>();

                foreach (var secondId in plans.Where(r => r.FirstCategoryID == firstId).Select(s => s.SecondCategoryID).Distinct())
                {
                    StoreSecondCategory second = new StoreSecondCategory();
                    second.SecondCategoryID = secondId;
                    second.SecondCategoryName = plans.First(r => r.FirstCategoryID == firstId && r.SecondCategoryID == secondId).SecondCategoryName;
                    second.ThirdStore = new List<StoreThirdCategory>();

                    foreach (var thirdId in plans.Where(r => r.FirstCategoryID == firstId && r.SecondCategoryID == secondId).Select(s => s.ThirdCategoryID).Distinct())
                    {
                        StoreThirdCategory third = new StoreThirdCategory();
                        third.ThirdCategoryID = thirdId;
                        third.ThirdCategoryName = plans.First(r => r.FirstCategoryID == firstId && r.SecondCategoryID == secondId && r.ThirdCategoryID == thirdId).ThirdCategoryName;
                        third.StoreCount = plans.Single(r => r.FirstCategoryID == firstId && r.SecondCategoryID == secondId && r.ThirdCategoryID == thirdId).StoreCount;
                        third.Weight = plans.Single(r => r.FirstCategoryID == firstId && r.SecondCategoryID == secondId && r.ThirdCategoryID == thirdId).Weight;

                        second.ThirdStore.Add(third);
                    }

                    second.StoreCount = second.ThirdStore.Sum(r => r.StoreCount);
                    second.Weight = second.ThirdStore.Sum(r => r.Weight);
                    first.SecondStore.Add(second);
                }
                first.StoreCount = first.SecondStore.Sum(r => r.StoreCount);
                first.Weight = first.SecondStore.Sum(r => r.Weight);
                data.FirstStore.Add(first);
            }

            data.StoreCount = data.FirstStore.Sum(r => r.StoreCount);
            data.Weight = data.FirstStore.Sum(r => r.Weight);
            return data;
        }

        /// <summary>
        /// 按客户获取付款信息
        /// </summary>
        /// <param name="customerType">客户类型</param>
        /// <param name="customerID">客户ID</param>
        /// <returns></returns>
        public List<Settlement> GetPaidSettleByCustomer(int customerType, int customerID)
        {
            var data = this.context.Settlements.Where(r => r.CustomerType == customerType && r.CustomerID == customerID && r.Status == (int)EntityStatus.SettlePaid);
            return data.ToList();
        }

        /// <summary>
        /// 获取库存分类汇总
        /// </summary>
        /// <param name="firstCategoryID">一级分类</param>
        /// <param name="secondCategoryID">二级分类</param>
        /// <returns></returns>
        public List<StoreThirdCategory> GetStoreCategorySummary(int firstCategoryID, int secondCategoryID)
        {
            var stores = this.context.Stocks.Where(r => r.Status == (int)EntityStatus.StoreIn);

            var records = from r in stores
                          where r.Cargo.FirstCategoryID == firstCategoryID && r.Cargo.SecondCategoryID == secondCategoryID
                          group r by r.Cargo.ThirdCategoryID into g
                          select new { g.Key, Count = g.Sum(r => r.Count) };

            List<StoreThirdCategory> data = new List<StoreThirdCategory>();

            foreach (var item in records)
            {
                StoreThirdCategory third = new StoreThirdCategory();
                third.ThirdCategoryID = item.Key == null ? 0 : item.Key.Value;
                third.StoreCount = item.Count;

                if (third.ThirdCategoryID != 0)
                {
                    third.ThirdCategoryName = this.context.ThirdCategories.Find(third.ThirdCategoryID).Name;
                }
                else
                    third.ThirdCategoryName = "(无)";

                data.Add(third);
            }

            return data;
        }

        /// <summary>
        /// 对指定库存进行分类统计
        /// </summary>
        /// <param name="storage">库存</param>
        /// <returns></returns>
        public StoreClassifyModel ConvertToClassify(List<Storage> storage)
        {
            List<StoreClassifyPlanModel> plans = new List<StoreClassifyPlanModel>();
            foreach (var item in storage)
            {
                string number = string.Format("{0}-{1}-{2}", item.FirstCategoryID, item.SecondCategoryID, item.ThirdCategoryID);

                if (plans.Any(r => r.CategoryNumber == number))
                {
                    var model = plans.Single(r => r.CategoryNumber == number);
                    model.StoreCount += item.Count;
                    model.Weight += item.Weight;
                }
                else
                {
                    StoreClassifyPlanModel model = new StoreClassifyPlanModel
                    {
                        CategoryNumber = number,
                        FirstCategoryID = item.FirstCategoryID,
                        FirstCategoryName = item.FirstCategoryName,
                        SecondCategoryID = item.SecondCategoryID,
                        SecondCategoryName = item.SecondCategoryName,
                        ThirdCategoryID = item.ThirdCategoryID,
                        ThirdCategoryName = item.ThirdCategoryName,
                        StoreCount = item.Count,
                        Weight = item.Weight
                    };

                    plans.Add(model);
                }
            }

            StoreClassifyModel data = new StoreClassifyModel();
            data.FirstStore = new List<StoreFirstCategory>();

            foreach (var firstId in plans.Select(r => r.FirstCategoryID).Distinct())
            {
                StoreFirstCategory first = new StoreFirstCategory();
                first.FirstCategoryID = firstId;
                first.FirstCategoryName = plans.First(r => r.FirstCategoryID == firstId).FirstCategoryName;
                first.SecondStore = new List<StoreSecondCategory>();

                foreach (var secondId in plans.Where(r => r.FirstCategoryID == firstId).Select(s => s.SecondCategoryID).Distinct())
                {
                    StoreSecondCategory second = new StoreSecondCategory();
                    second.SecondCategoryID = secondId;
                    second.SecondCategoryName = plans.First(r => r.FirstCategoryID == firstId && r.SecondCategoryID == secondId).SecondCategoryName;
                    second.ThirdStore = new List<StoreThirdCategory>();

                    foreach (var thirdId in plans.Where(r => r.FirstCategoryID == firstId && r.SecondCategoryID == secondId).Select(s => s.ThirdCategoryID).Distinct())
                    {
                        StoreThirdCategory third = new StoreThirdCategory();
                        third.ThirdCategoryID = thirdId;
                        third.ThirdCategoryName = plans.First(r => r.FirstCategoryID == firstId && r.SecondCategoryID == secondId && r.ThirdCategoryID == thirdId).ThirdCategoryName;
                        third.StoreCount = plans.Single(r => r.FirstCategoryID == firstId && r.SecondCategoryID == secondId && r.ThirdCategoryID == thirdId).StoreCount;
                        third.Weight = plans.Single(r => r.FirstCategoryID == firstId && r.SecondCategoryID == secondId && r.ThirdCategoryID == thirdId).Weight;

                        second.ThirdStore.Add(third);
                    }

                    second.StoreCount = second.ThirdStore.Sum(r => r.StoreCount);
                    second.Weight = second.ThirdStore.Sum(r => r.Weight);
                    first.SecondStore.Add(second);
                }
                first.StoreCount = first.SecondStore.Sum(r => r.StoreCount);
                first.Weight = first.SecondStore.Sum(r => r.Weight);
                data.FirstStore.Add(first);
            }

            data.StoreCount = data.FirstStore.Sum(r => r.StoreCount);
            data.Weight = data.FirstStore.Sum(r => r.Weight);
            return data;
        }

        /// <summary>
        /// 获取库存分类流水
        /// </summary>
        /// <param name="firstCategoryID">一类ID</param>
        /// <param name="secondCategoryID">二类ID</param>
        /// <param name="thirdCategoryID">三类ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        public List<CategoryFlow> GetStoreCategoryFlow(int firstCategoryID, int secondCategoryID, int? thirdCategoryID, DateTime start, DateTime end)
        {
            List<CategoryFlow> data = new List<CategoryFlow>();

            StoreBusiness storeBusiness = new StoreBusiness();

            for (DateTime step = start; step <= end; step = step.AddDays(1))
            {
                var flows = storeBusiness.GetDaysFlow(firstCategoryID, secondCategoryID, thirdCategoryID, step);
                data.AddRange(flows);
            }

            return data;
        }

        /// <summary>
        /// 获取收款记录
        /// </summary>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        public List<Receipt> GetReceiptRecords(DateTime start, DateTime end)
        {
            List<Receipt> data = new List<Receipt>();

            var settles = this.context.Settlements.Where(r => r.Status == (int)EntityStatus.SettlePaid && r.ConfirmTime >= start && r.ConfirmTime <= end);

            foreach (var item in settles)
            {
                Receipt receipt = new Receipt();
                receipt.CustomerType = item.CustomerType;
                receipt.CustomerID = item.CustomerID;
                receipt.CustomerName = item.CustomerName();
                receipt.StartTime = item.StartTime;
                receipt.EndTime = item.EndTime;
                receipt.TotalPrice = item.TotalPrice;
                receipt.PaidPrice = item.PaidPrice.Value;
                receipt.Difference = receipt.PaidPrice - receipt.TotalPrice;
                receipt.ConfirmTime = item.ConfirmTime.Value;

                data.Add(receipt);
            }

            return data;
        }


        #endregion //Method
    }
}