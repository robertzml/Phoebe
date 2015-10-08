using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Model
{
    public class TransferDetailMetadata
    {
        /// <summary>
        /// ID
        /// </summary>
        [Display(Name = "ID")]
        public System.Guid ID { get; set; }

        /// <summary>
        /// 转户ID
        /// </summary>
        [Display(Name = "转户ID")]
        public System.Guid TransferID { get; set; }

        /// <summary>
        /// 仓库ID
        /// </summary>
        [Display(Name = "库位")]
        public int WarehouseID { get; set; }

        /// <summary>
        /// 转户数量
        /// </summary>
        [Display(Name = "转户数量")]
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

    [MetadataType(typeof(TransferDetailMetadata))]
    public partial class TransferDetail
    {
    }
}
