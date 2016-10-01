using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phoebe.Business
{
    using Phoebe.Base;
    using Phoebe.Model;
    using Phoebe.Business.DAL;

    /// <summary>
    /// 统计业务类
    /// </summary>
    public class StatisticBusiness
    {
        #region Method
        /// <summary>
        /// 获取费用日报表
        /// </summary>
        /// <param name="date">日期</param>
        /// <returns></returns>
        public List<DailyFee> GetDailyFee(DateTime date)
        {
            List<DailyFee> data = new List<DailyFee>();

            var customers = BusinessFactory<CustomerBusiness>.Instance.FindAll();

            foreach (var customer in customers)
            {
                var dailyFee = GetCustomerDailyFee(customer.Id, date);

                if (dailyFee.TotalFee == 0)
                    continue;

                data.Add(dailyFee);
            }

            return data;
        }

        /// <summary>
        /// 获取客户费用日报表
        /// </summary>
        /// <param name="customerId">客户ID</param>
        /// <param name="date">日期</param>
        /// <returns></returns>
        public DailyFee GetCustomerDailyFee(int customerId, DateTime date)
        {
            DailyFee data = new DailyFee();

            var customer = BusinessFactory<CustomerBusiness>.Instance.FindById(customerId);

            data.CustomerId = customerId;
            data.CustomerNumber = customer.Number;
            data.CustomerName = customer.Name;
            data.Date = date;
            data.BaseFee = 0;
            data.ColdFee = 0;
            data.MiscFee = 0;

            var contracts = BusinessFactory<ContractBusiness>.Instance.GetByCustomer(customerId);

            foreach (var contract in contracts)
            {
                var contractBill = ContractFactory.Create((ContractType)contract.Type);

                var baseSettle = contractBill.GetBaseFee(contract.Id, date, date);
                if (baseSettle != null)
                    data.BaseFee += baseSettle.Sum(r => r.TotalPrice);

                var coldSettle = contractBill.GetColdFee(contract.Id, date, date);
                if (coldSettle != null)
                    data.ColdFee += coldSettle.ColdFee;

                var miscSettle = contractBill.GetMiscFee(contract.Id, date, date);
                if (miscSettle != null)
                    data.MiscFee += miscSettle.TotalFee;
            }

            data.TotalFee = data.BaseFee + data.ColdFee + data.MiscFee;

            return data;
        }

        /// <summary>
        /// 获取费用期报表
        /// </summary>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        public List<PeriodFee> GetPeriodFee(DateTime start, DateTime end)
        {
            List<PeriodFee> data = new List<PeriodFee>();

            var customers = BusinessFactory<CustomerBusiness>.Instance.FindAll();

            foreach (var customer in customers)
            {
                var dailyFee = GetCustomerPeriodFee(customer.Id, start, end);

                if (dailyFee.TotalFee == 0)
                    continue;

                data.Add(dailyFee);
            }

            return data;
        }

        /// <summary>
        /// 获取客户费用期报表
        /// </summary>
        /// <param name="customerId">客户ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        public PeriodFee GetCustomerPeriodFee(int customerId, DateTime start, DateTime end)
        {
            PeriodFee data = new PeriodFee();

            var customer = BusinessFactory<CustomerBusiness>.Instance.FindById(customerId);

            data.CustomerId = customerId;
            data.CustomerNumber = customer.Number;
            data.CustomerName = customer.Name;
            data.Start = start;
            data.End = end;
            data.BaseFee = 0;
            data.ColdFee = 0;
            data.MiscFee = 0;

            var contracts = BusinessFactory<ContractBusiness>.Instance.GetByCustomer(customerId);

            foreach (var contract in contracts)
            {
                var contractBill = ContractFactory.Create((ContractType)contract.Type);

                var baseSettle = contractBill.GetBaseFee(contract.Id, start, end);
                if (baseSettle != null)
                    data.BaseFee += baseSettle.Sum(r => r.TotalPrice);

                var coldSettle = contractBill.GetColdFee(contract.Id, start, end);
                if (coldSettle != null)
                    data.ColdFee += coldSettle.ColdFee;

                var miscSettle = contractBill.GetMiscFee(contract.Id, start, end);
                if (miscSettle != null)
                    data.MiscFee += miscSettle.TotalFee;
            }

            data.TotalFee = data.BaseFee + data.ColdFee + data.MiscFee;

            return data;
        }

        /// <summary>
        /// 获取指定日在库库存
        /// </summary>
        /// <param name="date">日期</param>
        /// <returns></returns>
        public List<Storage> GetDailyStorage(DateTime date)
        {
            List<Storage> data;

            data = BusinessFactory<StoreBusiness>.Instance.GetInDay(date);
            return data;
        }

        /// <summary>
        /// 获取指定日客户在库库存
        /// </summary>
        /// <param name="date">日期</param>
        /// <param name="customerId">客户ID</param>
        /// <returns></returns>
        public List<Storage> GetDailyStorage(DateTime date, int customerId)
        {
            List<Storage> data = new List<Storage>();

            var contracts = BusinessFactory<ContractBusiness>.Instance.GetByCustomer2(customerId);

            foreach (var contract in contracts)
            {
                var item = BusinessFactory<StoreBusiness>.Instance.GetInDay(contract.Id, date);
                data.AddRange(item);
            }

            return data;
        }

        /// <summary>
        /// 获取指定日客户货品库存
        /// </summary>
        /// <param name="customerId">客户ID</param>
        /// <param name="date">日期</param>
        /// <returns></returns>
        public List<CargoStore> GetCargoStore(int customerId, DateTime date)
        {
            List<CargoStore> data = new List<CargoStore>();

            var storages = GetDailyStorage(date, customerId);
            foreach (var item in storages)
            {
                if (data.Any(r => r.CargoId == item.CargoId))
                {
                    var s = data.Single(r => r.CargoId == item.CargoId);
                    s.TotalCount += item.TotalCount;
                    s.StoreCount += item.Count;
                    s.StoreWeight += item.StoreWeight;
                    s.StoreVolume += item.StoreVolume;
                }
                else
                {
                    CargoStore cs = new CargoStore
                    {
                        StorageDate = item.StorageDate,
                        CustomerId = item.CustomerId,
                        CustomerNumber = item.CustomerNumber,
                        CustomerName = item.CustomerName,
                        ContractId = item.ContractId,
                        ContractName = item.ContractName,
                        CargoId = item.CargoId,
                        CategoryId = item.CategoryId,
                        CategoryNumber = item.CategoryNumber,
                        CategoryName = item.CategoryName,
                        Specification = item.Specification,
                        TotalCount = item.TotalCount,
                        StoreCount = item.Count,
                        UnitWeight = item.UnitWeight,
                        StoreWeight = item.StoreWeight,
                        UnitVolume = item.UnitVolume,
                        StoreVolume = item.StoreVolume
                    };

                    data.Add(cs);
                }
            }

            return data;
        }
        #endregion //Method
    }
}
