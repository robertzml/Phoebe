using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Core.DL
{
    using Poseidon.Base.Framework;

    /// <summary>
    /// 货品类
    /// </summary>
    public class Cargo : BaseEntity
    {
        #region Property
        /// <summary>
        /// 分类ID
        /// </summary>
        [Display(Name = "分类ID")]
        public int CategoryId { get; set; }

        /// <summary>
        /// 分组方式
        /// </summary>
        [Display(Name = "分组方式")]
        public int GroupType { get; set; }

        /// <summary>
        /// 单位重量(kg)
        /// </summary>
        [Display(Name = "单位重量(kg)")]
        public decimal UnitWeight { get; set; }

        /// <summary>
        /// 单位体积(m3)
        /// </summary>
        [Display(Name = "单位体积(m3)")]
        public decimal UnitVolume { get; set; }

        /// <summary>
        /// 合同ID
        /// </summary>
        [Display(Name = "合同ID")]
        public int ContractId { get; set; }

        /// <summary>
        /// 登记时间
        /// </summary>
        [Display(Name = "登记时间")]
        public DateTime RegisterTime { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Display(Name = "状态")]
        public int Status { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        public string Remark { get; set; }
        #endregion //Property
    }
}
