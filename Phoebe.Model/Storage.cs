using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Model
{
    /// <summary>
    /// 库位存储类
    /// </summary>
    public class Storage
    {
        /// <summary>
        /// 库位ID
        /// </summary>
        [Display(Name = "库位ID")]
        public int WarehouseID { get; set; }

        /// <summary>
        /// 库位编号
        /// </summary>
        [Required]
        [Display(Name = "库位编号")]
        public string Number { get; set; }

        /// <summary>
        /// 库存ID
        /// </summary>
        [Display(Name = "库存ID")]
        public System.Guid StockID { get; set; }

        /// <summary>
        /// 货品ID
        /// </summary>
        [Display(Name = "货品")]
        public System.Guid CargoID { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [Display(Name = "数量")]
        public int Count { get; set; }

        /// <summary>
        /// 入库时间
        /// </summary>
        [Display(Name = "入库时间")]
        public System.DateTime InTime { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        [Display(Name = "来源")]
        public int Source { get; set; }
    }
}
