using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Model
{
    public class StockOutDetailMetadata
    {
        /// <summary>
        /// ID
        /// </summary>
        [Display(Name = "ID")]
        public System.Guid ID { get; set; }

        /// <summary>
        /// 出库ID
        /// </summary>
        [Display(Name = "出库记录")]
        public System.Guid StockOutID { get; set; }

        /// <summary>
        /// 仓库ID
        /// </summary>
        [Display(Name = "库位")]
        public int WarehouseID { get; set; }

        /// <summary>
        /// 货品ID
        /// </summary>
        [Display(Name = "货品")]
        public System.Guid CargoID { get; set; }

        /// <summary>
        /// 在库数量
        /// </summary>
        [Display(Name = "在库数量")]
        public int StoreCount { get; set; }

        /// <summary>
        /// 出库数量
        /// </summary>
        [Display(Name = "出库数量")]
        public int Count { get; set; }

        /// <summary>
        /// 库存ID
        /// </summary>
        [Display(Name = "库存记录")]
        public System.Guid StockID { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataType(DataType.MultilineText)]
        [Display(Name = "备注")]
        public string Remark { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Display(Name = "状态")]
        public int Status { get; set; }
    }

    [MetadataType(typeof(StockOutDetailMetadata))]
    public partial class StockOutDetail
    {
    }
}
