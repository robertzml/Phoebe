using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Model
{
    /// <summary>
    /// 日冷藏费记录
    /// </summary>
    public class DailyColdRecord
    {
        /// <summary>
        /// 日期
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "日期")]
        public DateTime RecordDate { get; set; }

        /// <summary>
        /// 货品名称
        /// </summary>
        [Display(Name = "货品名称")]
        public string CargoName { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [Display(Name = "数量")]
        public int Count { get; set; }

        /// <summary>
        /// 单位计量
        /// </summary>
        [Display(Name = "单位计量")]
        public double UnitMeter { get; set; }

        /// <summary>
        /// 出入库计量
        /// </summary>
        [Display(Name = "出入库计量")]
        public decimal StoreMeter { get; set; }

        /// <summary>
        ///  计量累计
        /// </summary>
        [Display(Name = "计量累计")]
        public decimal TotalMeter { get; set; }

        /// <summary>
        /// 日冷藏费(元)
        /// </summary>
        [Display(Name = "日冷藏费(元)")]
        public decimal DailyFee { get; set; }

        /// <summary>
        /// 冷藏费累计(元)
        /// </summary>
        [Display(Name = "冷藏费累计(元)")]
        public decimal TotalFee { get; set; }
    }
}
