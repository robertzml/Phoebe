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
        /// 合同名称
        /// </summary>
        [Required]
        [Display(Name = "合同名称")]
        public string Name { get; set; }

        /// <summary>
        /// 客户类型
        /// </summary>
        [Required]
        [UIHint("CustomerType")]
        [Display(Name = "客户类型")]
        public int CustomerType { get; set; }

        /// <summary>
        /// 客户ID
        /// </summary>
        [Required]
        [Display(Name = "客户")]
        public int CustomerID { get; set; }

        /// <summary>
        /// 签订日期
        /// </summary>
        [Required]
        [Display(Name = "签订日期")]
        public System.DateTime SignDate { get; set; }

        /// <summary>
        /// 关闭日期
        /// </summary>
        [Display(Name = "关闭日期")]
        public Nullable<System.DateTime> CloseDate { get; set; }

        /// <summary>
        /// 计费方式
        /// </summary>
        [Required]
        [UIHint("BillingType")]
        [Display(Name = "计费方式")]
        public int BillingType { get; set; }

        /// <summary>
        /// 凭证编号
        /// </summary>
        [Display(Name = "凭证编号")]
        public string CertificateNumber { get; set; }

        /// <summary>
        /// 登记人
        /// </summary>
        [Display(Name = "登记人")]
        public int UserID { get; set; }

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
