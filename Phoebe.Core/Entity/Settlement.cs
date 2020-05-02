using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Phoebe.Core.Entity
{
    using Phoebe.Base.Framework;
    using SqlSugar;

    /// <summary>
    /// 结算类
    /// </summary>
    [SugarTable("Settlement")]
    public class Settlement : IBaseEntity<string>
    {
        #region Property
        /// <summary>
        /// ID
        /// </summary>
        [SugarColumn(ColumnName = "Id", IsPrimaryKey = true)]
        [Display(Name = "ID")]
        public string Id { get; set; }

        /// <summary>
        /// 结算单号
        /// </summary>
        [Display(Name = "结算单号")]
        public string Number { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        [Display(Name = "用户ID")]
        public int CustomerId { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        [Display(Name = "开始日期")]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        [Display(Name = "结束日期")]
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 费用合计
        /// </summary>
        [Display(Name = "费用合计")]
        public decimal SumFee { get; set; }

        /// <summary>
        /// 折扣率
        /// </summary>
        [Display(Name = "折扣率")]
        public int Discount { get; set; }

        /// <summary>
        /// 减免费用
        /// </summary>
        [Display(Name = "减免费用")]
        public decimal Remission { get; set; }

        /// <summary>
        /// 应付款
        /// </summary>
        [Display(Name = "应付款")]
        public decimal DueFee { get; set; }

        /// <summary>
        /// 结算日期
        /// </summary>
        [Display(Name = "结算日期")]
        public DateTime SettleTime { get; set; }

        /// <summary>
        /// 登记人ID
        /// </summary>
        [Display(Name = "登记人ID")]
        public int UserId { get; set; }

        /// <summary>
        /// 登记人
        /// </summary>
        [Display(Name = "登记人")]
        public string UserName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        public string Remark { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Display(Name = "状态")]
        public int Status { get; set; }
        #endregion //Property
    }
}
