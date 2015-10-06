using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoebe.Model;

namespace Phoebe.Business
{
    /// <summary>
    /// 转户业务类
    /// </summary>
    public class TransferBusiness
    {
        #region Field
        private PhoebeContext context;
        #endregion //Field

        #region Constructor
        public TransferBusiness()
        {
            this.context = new PhoebeContext();
        }
        #endregion //Constructor
    }
}
