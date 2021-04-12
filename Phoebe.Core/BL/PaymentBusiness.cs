using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.BL
{
    using SqlSugar;
    using Phoebe.Base.Framework;
    using Phoebe.Core.Entity;
    using Phoebe.Core.Utility;

    /// <summary>
    /// 缴费业务类
    /// </summary>
    public class PaymentBusiness : AbstractBusiness<Payment, string>, IBaseBL<Payment, string>
    {
        #region Method
        public override (bool success, string errorMessage, Payment t) Create(Payment entity, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            SequenceRecordBusiness recordBusiness = new SequenceRecordBusiness();

            entity.Id = Guid.NewGuid().ToString();
            entity.TicketNumber = recordBusiness.GetNextSequence(db, "Payment", entity.PaidTime);
            entity.CreateTime = DateTime.Now;
            entity.Status = 0;

            var t = db.Insertable(entity).ExecuteReturnEntity();

            return (true, "", t);
        }

        public override (bool success, string errorMessage) Update(Payment entity, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var payment = db.Queryable<Payment>().InSingle(entity.Id);
            if (payment.PaidTime != entity.PaidTime)
            {
                payment.PaidTime = entity.PaidTime;

                SequenceRecordBusiness recordBusiness = new SequenceRecordBusiness();
                payment.TicketNumber = recordBusiness.GetNextSequence(db, "Payment", entity.PaidTime);                
            }

            payment.PaidType = entity.PaidType;
            payment.PaidFee = entity.PaidFee;
            payment.Remark = entity.Remark;

            return base.Update(payment, db);
        }
        #endregion //Method
    }
}
