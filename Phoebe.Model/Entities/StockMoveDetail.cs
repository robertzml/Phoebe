using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Model
{
    public class StockMoveDetailMetadata
    {
        /// <summary>
        /// ID
        /// </summary>
        [Display(Name = "ID")]
        public System.Guid ID { get; set; }

        /// <summary>
        /// 移库ID
        /// </summary>
        [Display(Name = "移库记录")]
        public System.Guid StockMoveID { get; set; }

        /// <summary>
        /// 源仓库ID
        /// </summary>
        [Display(Name = "源库位")]
        public int SourceWarehouseID { get; set; }

        /// <summary>
        /// 目的仓库ID
        /// </summary>
        [Display(Name = "目的库位")]
        public int DestinationWarehouseID { get; set; }

        /// <summary>
        /// 货品ID
        /// </summary>
        [Display(Name = "货品")]
        public System.Guid CargoID { get; set; }

        /// <summary>
        /// 移库数量
        /// </summary>
        [Display(Name = "移库数量")]
        public int Count { get; set; }

        /// <summary>
        /// 源库存ID
        /// </summary>
        [Display(Name = "源库存记录")]
        public System.Guid SourceStockID { get; set; }

        /// <summary>
        /// 目的库存ID
        /// </summary>
        [Display(Name = "目的库存记录")]
        public Nullable<System.Guid> DestinationStockID { get; set; }

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

    [MetadataType(typeof(StockMoveDetailMetadata))]
    public partial class StockMoveDetail
    {
    }
}
