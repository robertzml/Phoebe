using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Model
{
    public class SettlementDetailMetadata
    {
        /// <summary>
        /// ID
        /// </summary>
        [Display(Name = "ID")]
        public System.Guid ID { get; set; }

        /// <summary>
        /// 结算ID
        /// </summary>
        [Display(Name = "结算ID")]
        public System.Guid SettlementID { get; set; }

        /// <summary>
        /// 货品ID
        /// </summary>
        [Display(Name = "相关货品")]
        public Nullable<System.Guid> CargoID { get; set; }

        /// <summary>
        /// 合同ID
        /// </summary>
        [Display(Name = "相关合同")]
        public Nullable<int> ContractID { get; set; }

        /// <summary>
        /// 费用类型
        /// </summary>
        [Display(Name = "费用类型")]
        public int ExpenseType { get; set; }

        /// <summary>
        /// 费用合计
        /// </summary>
        [Display(Name = "费用合计(元)")]
        public decimal SumPrice { get; set; }

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

    [MetadataType(typeof(SettlementDetailMetadata))]
    public partial class SettlementDetail
    {
    }
}
