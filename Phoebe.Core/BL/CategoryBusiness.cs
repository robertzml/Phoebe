using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Core.BL
{
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Common;
    using Phoebe.Core.IDAL;
    using Phoebe.Core.DL;

    /// <summary>
    /// 类别业务类
    /// </summary>
    public class CategoryBusiness : AbstractBusiness<Category, int>, IBaseBL<Category, int>
    {
        #region Constructor
        /// <summary>
        /// 类别业务类
        /// </summary>
        public CategoryBusiness()
        {
            this.baseDal = RepositoryFactory<ICategoryRepository>.Instance;
        }
        #endregion //Constructor
    }
}
