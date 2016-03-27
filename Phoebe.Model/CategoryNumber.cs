using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Model
{
    /// <summary>
    /// 分类编码
    /// </summary>
    public class CategoryNumber
    {
        #region Method
        public override string ToString()
        {
            if (Level == 2)
                return string.Format("{0}-{1}", Number, SecondCategoryName);
            else if (Level == 3)
                return string.Format("{0}-{1}-{2}", Number, SecondCategoryName, ThirdCategoryName);
            else
                return "";
        }

        public string GetName()
        {
            if (Level == 2)
                return string.Format("{0}", SecondCategoryName);
            else if (Level == 3)
                return string.Format("{0}-{1}", SecondCategoryName, ThirdCategoryName);
            else
                return "";
        }
        #endregion //Method

        #region Property
        /// <summary>
        /// 级别
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 一级分类
        /// </summary>
        public int FirstCategoryId { get; set; }

        /// <summary>
        /// 二级分类
        /// </summary>
        public int SecondCatgoryId { get; set; }

        /// <summary>
        /// 二级分类名称
        /// </summary>
        public string SecondCategoryName { get; set; }

        /// <summary>
        /// 三级分类
        /// </summary>
        public int ThirdCategoryId { get; set; }

        /// <summary>
        /// 三级分类名称
        /// </summary>
        public string ThirdCategoryName { get; set; }
        #endregion //Property
    }
}
