using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Business
{
    using Phoebe.Model;

    /// <summary>
    ///  合同计费工厂方法
    /// </summary>
    public static class ContractFactory
    {
        /// <summary>
        /// 创建合同计费
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
                case ContractType.UntimingCold:
                    contract = new UntimingColdContract();
                    break;
                case ContractType.Freeze:
                    contract = new FreezeContract();
                    break;
                case ContractType.Ice:
                    contract = new IceContract();
                    break;
            }
            return contract;
        }
    }
}
