using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Model
{
    public class ContractMetadata
    {
        /// <summary>
        /// ID
        /// </summary>
        [Display(Name = "ID")]
        public int ID { get; set; }

        /// <summary>
        /// 合同编号
        /// </summary>
        [Required]
        [Display(Name = "合同编号")]
        public string Number { get; set; }

        /// <summary>
        /// 合同类型
        /// </summary>
        [Required]
        [UIHint("ContractType")]
        [Display(Name = "合同类型")]
        public int Type { get; set; }

        /// <summary>
        /// 客户类型
        /// </summary>
        [Required]
        [Display(Name = "客户类型")]
        public int CustomerType { get; set; }

        /// <summary>
        /// 客户ID
        /// </summary>
        [Required]
        [Display(Name = "客户ID")]
        public int CustomerID { get; set; }

        /// <summary>
        /// 签订日期
        /// </summary>
        [Required]
        [Display(Name = "签订日期")]
        public System.DateTime SignDate { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        [Required]
        [Display(Name = "开始日期")]
        public System.DateTime StartDate { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        [Required]
        [Display(Name = "结束日期")]
        public System.DateTime EndDate { get; set; }

        /// <summary>
        /// 凭证编号
        /// </summary>
        [Required]
        [Display(Name = "凭证编号")]
        public string CertificateNumber { get; set; }

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

    [MetadataType(typeof(ContractMetadata))]
    public partial class Contract
    {
    }
}
