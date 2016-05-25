using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phoebe.Business
{
    using Phoebe.Model;

    /// <summary>
    /// 计费方式工厂方法
    /// </summary>
    public static class BillingFactory
    {
        /// <summary>
        /// 创建计费
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IBillingProcess Create(BillingType type)
        {
            IBillingProcess billingProcess = null;
            switch (type)
            {
                case BillingType.UnitWeight:
                    billingProcess = new BillingUnitWeight();
                    break;
                case BillingType.UnitVolume:
                    billingProcess = new BillingUnitVolume();
                    break;
                case BillingType.Count:
                    billingProcess = new BillingCount();
                    break;
                case BillingType.VariousWeight:
                    billingProcess = new BillingVariousWeight();
                    break;
            }
            return billingProcess;
        }
    }
}
