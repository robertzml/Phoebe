﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.BL
{
    using SqlSugar;
    using Phoebe.Base.Framework;
    using Phoebe.Base.System;
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

            entity.Id = Guid.NewGuid().ToString();
            entity.CreateTime = DateTime.Now;
            entity.Status = 0;

            var t = db.Insertable(entity).ExecuteReturnEntity();

            return (true, "", t);
        }
        #endregion //Method
    }
}