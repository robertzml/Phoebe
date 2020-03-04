using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.Billing
{
    using Phoebe.Core.Utility;

    /// <summary>
    /// 合同工厂类
    /// </summary>
    public static class ContractFactory
    {
        /// <summary>
        /// 创建合同
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IContract Create(ContractType type)
        {
            IContract contract = null;
            switch (type)
            {
                case ContractType.TimingCold:
                    contract = new TimingColdContract();
                    break;
                    //case ContractType.UntimingCold:
                    //    contract = new UntimingColdContract();
                    //    break;
                    //case ContractType.Freeze:
                    //    contract = new FreezeContract();
                    //    break;
                    //case ContractType.Ice:
                    //    contract = new IceContract();
                    //    break;                
            }
            return contract;
        }
    }
}
