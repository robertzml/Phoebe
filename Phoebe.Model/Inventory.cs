using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Model
{
    /// <summary>
    /// 库存盘点类
    /// </summary>
    public class Inventory
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// 客户ID
        /// </summary>
        public int CustomerID { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName { get; set; }

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
        /// 期初时间
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 期初数量
        /// </summary>
        public int StartCount { get; set; }

        /// <summary>
        /// 期初重量
        /// </summary>
        public double StartWeight { get; set; }

        /// <summary>
        /// 期末时间
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 期末数量
        /// </summary>
        public int EndCount { get; set; }

        /// <summary>
        /// 期末重量
        /// </summary>
        public double EndWeight { get; set; }
    }
}
