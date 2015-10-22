using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoebe.Model;

namespace Phoebe.Business
{
    /// <summary>
    /// 结算业务类
    /// </summary>
    public class SettleBusiness
    {
        #region Field
        private PhoebeContext context;
        #endregion //Field

        #region Constructor
        public SettleBusiness()
        {
            this.context = new PhoebeContext();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 获取基本费用结算
        /// </summary>
        /// <returns></returns>
        public List<BaseSettlement> GetBase()
        {
            var data = this.context.BaseSettlements.OrderByDescending(r => r.ConfirmTime);
            return data.ToList();
        }

        /// <summary>
        /// 获取基本费用结算
        /// </summary>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public List<BaseSettlement> GetBase(EntityStatus status)
        {
            var data = this.context.BaseSettlements.Where(r => r.Status == (int)status);
            return data.ToList();
        }

        /// <summary>
        /// 获取基本费用结算
        /// </summary>
        /// <param name="id">结算ID</param>
        /// <returns></returns>
        public BaseSettlement GetBase(string id)
        {
            Guid gid;
            if (!Guid.TryParse(id, out gid))
                return null;

            return this.context.BaseSettlements.Find(gid);
        }

        /// <summary>
        /// 添加基本结算信息
        /// </summary>
        /// <param name="data">基本结算数据</param>
        /// <returns></returns>
        public ErrorCode BaseCreate(BaseSettlement data)
        {
            try
            {
                data.ID = Guid.NewGuid();
                data.Status = (int)EntityStatus.SettleUnpaid;

                this.context.BaseSettlements.Add(data);

                //edit cargo billing
                var billing = this.context.Billings.Find(data.CargoID);
                if (billing.Status != (int)EntityStatus.BillingUnsettle)
                {
                    return ErrorCode.CargoCannotSettled;
                }

                billing.Status = (int)EntityStatus.BillingSettle;

                this.context.SaveChanges();
            }
            catch (Exception e)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }

        /// <summary>
        /// 基本结算审核
        /// </summary>
        /// <param name="id">结算ID</param>
        /// <param name="paidPrice">付款</param>
        /// <param name="confirmTime">确认时间</param>
        /// <param name="remark">备注</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public ErrorCode BaseAudit(string id, decimal paidPrice, DateTime confirmTime, string remark, EntityStatus status)
        {
            try
            {
                Guid gid;
                if (!Guid.TryParse(id, out gid))
                    return ErrorCode.ObjectNotFound;

                BaseSettlement baseSettle = this.context.BaseSettlements.Find(gid);
                if (baseSettle == null)
                    return ErrorCode.ObjectNotFound;

                baseSettle.PaidPrice = paidPrice;
                baseSettle.ConfirmTime = confirmTime;
                baseSettle.Remark = remark;
                baseSettle.Status = (int)status;

                BillingBusiness billingBusiness = new BillingBusiness();
                var billing = this.context.Billings.Find(baseSettle.CargoID);

                if (status == EntityStatus.SettlePaid)
                {
                    billing.Status = (int)EntityStatus.BillingPaid;
                }
                else
                {
                    baseSettle.PaidPrice = null;
                    billing.Status = (int)EntityStatus.BillingUnsettle;
                }

                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }

        /// <summary>
        /// 冷藏费计算
        /// </summary>
        /// <param name="contractID">合同ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <param name="dailyFee">冷藏费单价</param>
        /// <returns></returns>
        public List<ChargeRecord> Process(int contractID, DateTime start, DateTime end, double dailyFee)
        {
            var cargos = this.context.Cargoes.Where(r => r.ContractID == contractID);

            var stockIns = from r in this.context.StockIns
                           where r.Status == (int)EntityStatus.StockIn && r.ConfirmTime >= start && r.ConfirmTime <= end &&
                                cargos.Select(s => s.ID).Contains(r.CargoID)
                           select r;

            var stockOuts = from r in this.context.StockOuts
                            where r.Status == (int)EntityStatus.StockOut && r.ConfirmTime >= start && r.ConfirmTime <= end &&
                                cargos.Select(s => s.ID).Contains(r.CargoID)
                            select r;

            var transferIns = from r in this.context.Transfers
                              where r.Status == (int)EntityStatus.Transfer && r.ConfirmTime >= start && r.ConfirmTime <= end &&
                                cargos.Select(s => s.ID).Contains(r.NewCargoID)
                              select r;

            var transferOuts = from r in this.context.Transfers
                               where r.Status == (int)EntityStatus.Transfer && r.ConfirmTime >= start && r.ConfirmTime <= end &&
                                cargos.Select(s => s.ID).Contains(r.OldCargoID)
                               select r;

            decimal totalWeight = 0;
            decimal totalFee = 0;

            List<ChargeRecord> records = new List<ChargeRecord>();
            for (DateTime step = start.Date; step <= end; step = step.AddDays(1))
            {
                var nextDay = step.AddDays(1);
                int todayCount = 0;

                //find stocks in day
                var ins = stockIns.Where(r => r.ConfirmTime >= step && r.ConfirmTime < nextDay);
                if (ins.Count() != 0)
                {
                    foreach (var item in ins)
                    {
                        ChargeRecord record = new ChargeRecord();
                        record.RecordDate = step;

                        var c = cargos.Single(r => r.ID == item.CargoID);

                        record.RecordDate = step;
                        record.CargoName = c.Name;
                        record.UnitWeight = c.UnitWeight.Value;
                        record.Count = c.Count;
                        record.StoreWeight = Convert.ToDecimal(c.TotalWeight.Value);
                        totalWeight += record.StoreWeight;
                        record.TotalWeight = totalWeight;

                        records.Add(record);
                        todayCount++;
                    }

                    var last = records.Last();
                    last.DailyFee = last.TotalWeight * (decimal)dailyFee;
                    totalFee += last.DailyFee;
                    last.TotalFee = totalFee;
                }

                var tins = transferIns.Where(r => r.ConfirmTime >= step && r.ConfirmTime < nextDay);
                if (tins.Count() != 0)
                {
                    if (todayCount > 0)
                    {
                        var lastIn = records.Last();
                        totalFee -= lastIn.DailyFee;
                        lastIn.DailyFee = 0;
                        lastIn.TotalFee = 0;
                    }

                    foreach (var item in tins)
                    {
                        ChargeRecord record = new ChargeRecord();
                        record.RecordDate = step;

                        var c = cargos.Single(r => r.ID == item.NewCargoID);

                        record.RecordDate = step;
                        record.CargoName = c.Name;
                        record.UnitWeight = c.UnitWeight.Value;
                        record.Count = c.Count;
                        record.StoreWeight = Convert.ToDecimal(c.TotalWeight.Value);
                        totalWeight += record.StoreWeight;
                        record.TotalWeight = totalWeight;

                        records.Add(record);
                        todayCount++;
                    }

                    var last = records.Last();
                    last.DailyFee = last.TotalWeight * (decimal)dailyFee;
                    totalFee += last.DailyFee;
                    last.TotalFee = totalFee;
                }

                var outs = stockOuts.Where(r => r.ConfirmTime >= step && r.ConfirmTime < nextDay);
                if (outs.Count() != 0)
                {
                    if (todayCount > 0)
                    {
                        var lastIn = records.Last();
                        totalFee -= lastIn.DailyFee;
                        lastIn.DailyFee = 0;
                        lastIn.TotalFee = 0;
                    }

                    foreach (var item in outs)
                    {
                        ChargeRecord record = new ChargeRecord();
                        record.RecordDate = step;

                        var c = cargos.Single(r => r.ID == item.CargoID);

                        record.RecordDate = step;
                        record.CargoName = c.Name;
                        record.UnitWeight = c.UnitWeight.Value;

                        record.Count = -item.StockOutDetails.Sum(r => r.Count);
                        record.StoreWeight = Convert.ToDecimal(record.UnitWeight * record.Count / 1000);
                        totalWeight += record.StoreWeight;
                        record.TotalWeight = totalWeight;

                        records.Add(record);
                        todayCount++;
                    }

                    var last = records.Last();
                    last.DailyFee = last.TotalWeight * (decimal)dailyFee;
                    totalFee += last.DailyFee;
                    last.TotalFee = totalFee;
                }

                var touts = transferOuts.Where(r => r.ConfirmTime >= step && r.ConfirmTime < nextDay);
                if (touts.Count() != 0)
                {
                    if (todayCount > 0)
                    {
                        var lastIn = records.Last();
                        totalFee -= lastIn.DailyFee;
                        lastIn.DailyFee = 0;
                        lastIn.TotalFee = 0;
                    }

                    foreach (var item in touts)
                    {
                        ChargeRecord record = new ChargeRecord();
                        record.RecordDate = step;

                        var c = cargos.Single(r => r.ID == item.OldCargoID);

                        record.RecordDate = step;
                        record.CargoName = c.Name;
                        record.UnitWeight = c.UnitWeight.Value;

                        record.Count = -item.TransferDetails.Sum(r => r.Count);
                        record.StoreWeight = Convert.ToDecimal(record.UnitWeight * record.Count / 1000);
                        totalWeight += record.StoreWeight;
                        record.TotalWeight = totalWeight;

                        records.Add(record);
                        todayCount++;
                    }

                    var last = records.Last();
                    last.DailyFee = last.TotalWeight * (decimal)dailyFee;
                    totalFee += last.DailyFee;
                    last.TotalFee = totalFee;
                }

                if (todayCount == 0)
                {
                    ChargeRecord record = new ChargeRecord();
                    record.RecordDate = step;
                    record.TotalWeight = totalWeight;
                    record.DailyFee = record.TotalWeight * (decimal)dailyFee;
                    totalFee += record.DailyFee;
                    record.TotalFee = totalFee;

                    records.Add(record);
                }
            }

            return records;
        }
        #endregion //Method
    }
}
