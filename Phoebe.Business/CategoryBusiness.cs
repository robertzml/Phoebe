using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoebe.Model;

namespace Phoebe.Business
{
    /// <summary>
    /// 类别业务类
    /// </summary>
    public class CategoryBusiness
    {
        #region Field
        private PhoebeContext context;
        #endregion //Field

        #region Constructor
        public CategoryBusiness()
        {
            this.context = new PhoebeContext();
        }
        #endregion //Constructor
    }
}
