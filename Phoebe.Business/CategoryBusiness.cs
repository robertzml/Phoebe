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

        #region Method
        /// <summary>
        /// 获取所有一级分类
        /// </summary>
        /// <returns></returns>
        public List<FirstCategory> GetFirstCategory()
        {
            return this.context.FirstCategories.ToList();
        }

        /// <summary>
        /// 获取一级分类
        /// </summary>
        /// <param name="id">一级分类ID</param>
        /// <returns></returns>
        public FirstCategory GetFirstCategory(int id)
        {
            return this.context.FirstCategories.SingleOrDefault(r => r.ID == id);
        }

        /// <summary>
        /// 获取所有二级分类
        /// </summary>
        /// <returns></returns>
        public List<SecondCategory> GetSecondCategory()
        {
            return this.context.SecondCategories.ToList();
        }

        /// <summary>
        /// 获取二级分类
        /// </summary>
        /// <param name="id">二级分类ID</param>
        /// <returns></returns>
        public SecondCategory GetSecondCategory(int id)
        {
            return this.context.SecondCategories.SingleOrDefault(r => r.ID == id);
        }
        #endregion //Method
    }
}
