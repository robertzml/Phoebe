using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Model
{
    /// <summary>
    /// 库存分类汇总模型
    /// </summary>
    public class StoreClassifyPlanModel
    {
        /// <summary>
        /// 客户类型
        /// </summary>
        [Display(Name = "客户类型")]
        public int CustomerType { get; set; }

        /// <summary>
        /// 客户ID
        /// </summary>
        [Display(Name = "客户ID")]
        public int CustomerID { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        [Display(Name = "客户名称")]
        public string CustomerName { get; set; }

        /// <summary>
        /// 分类编号
        /// </summary>
        [Display(Name = "分类编号")]
        public string CategoryNumber { get; set; }

        /// <summary>
        /// 一级分类ID
        /// </summary>
        [Display(Name = "一级分类ID")]
        public int FirstCategoryID { get; set; }

        /// <summary>
        /// 一级分类
        /// </summary>
        [Display(Name = "一级分类")]
        public string FirstCategoryName { get; set; }

        /// <summary>
        /// 二级分类ID
        /// </summary>
        [Display(Name = "二级分类ID")]
        public int SecondCategoryID { get; set; }

        /// <summary>
        /// 二级分类
        /// </summary>
        [Display(Name = "二级分类")]
        public string SecondCategoryName { get; set; }

        /// <summary>
        /// 三级分类ID
        /// </summary>
        [Display(Name = "三级分类ID")]
        public int ThirdCategoryID { get; set; }

        /// <summary>
        /// 三级分类
        /// </summary>
        [Display(Name = "三级分类")]
        public string ThirdCategoryName { get; set; }

        /// <summary>
        /// 在库数量
        /// </summary>
        [Display(Name = "在库数量")]
        public int StoreCount { get; set; }
    }

    /// <summary>
    /// 库存分类汇总模型
    /// </summary>
    public class StoreClassifyModel
    {
        /// <summary>
        /// 客户类型
        /// </summary>
        [Display(Name = "客户类型")]
        public int CustomerType { get; set; }

        /// <summary>
        /// 客户ID
        /// </summary>
        [Display(Name = "客户ID")]
        public int CustomerID { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        [Display(Name = "客户名称")]
        public string CustomerName { get; set; }

        /// <summary>
        /// 一级分类
        /// </summary>
        public List<StoreFirstCategory> FirstStore { get; set; }

        /// <summary>
        /// 在库数量
        /// </summary>
        [Display(Name = "在库数量")]
        public int StoreCount { get; set; }
    }

    /// <summary>
    /// 库存一级分类
    /// </summary>
    public class StoreFirstCategory
    {
        /// <summary>
        /// 一级分类ID
        /// </summary>
        [Display(Name = "一级分类ID")]
        public int FirstCategoryID { get; set; }

        /// <summary>
        /// 一级分类
        /// </summary>
        [Display(Name = "一级分类")]
        public string FirstCategoryName { get; set; }

        /// <summary>
        /// 在库数量
        /// </summary>
        [Display(Name = "在库数量")]
        public int StoreCount { get; set; }

        /// <summary>
        /// 二级分类
        /// </summary>
        public List<StoreSecondCategory> SecondStore { get; set; }
    }

    /// <summary>
    /// 库存二级分类
    /// </summary>
    public class StoreSecondCategory
    {
        /// <summary>
        /// 二级分类ID
        /// </summary>
        [Display(Name = "二级分类ID")]
        public int SecondCategoryID { get; set; }

        /// <summary>
        /// 二级分类
        /// </summary>
        [Display(Name = "二级分类")]
        public string SecondCategoryName { get; set; }

        /// <summary>
        /// 在库数量
        /// </summary>
        [Display(Name = "在库数量")]
        public int StoreCount { get; set; }

        /// <summary>
        /// 三级分类
        /// </summary>
        public List<StoreThirdCategory> ThirdStore { get; set; }
    }

    /// <summary>
    /// 库存三级分类
    /// </summary>
    public class StoreThirdCategory
    {
        /// <summary>
        /// 分类编号
        /// </summary>
        [Display(Name = "分类编号")]
        public string CategoryNumber { get; set; }

        /// <summary>
        /// 三级分类ID
        /// </summary>
        [Display(Name = "三级分类ID")]
        public int ThirdCategoryID { get; set; }

        /// <summary>
        /// 三级分类
        /// </summary>
        [Display(Name = "三级分类")]
        public string ThirdCategoryName { get; set; }

        /// <summary>
        /// 在库数量
        /// </summary>
        [Display(Name = "在库数量")]
        public int StoreCount { get; set; }
    }
}
