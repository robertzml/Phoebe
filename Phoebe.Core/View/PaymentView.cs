using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Phoebe.Core.View
{
    using Phoebe.Base.Framework;
    using SqlSugar;

    /// <summary>
    /// 缴费视图类
    /// </summary>
    [SugarTable("PaymentView")]
    public class PaymentView : IBaseEntity<string>
    {
        #region Property
        /// <summary>
        /// ID
        /// </summary>
        [SugarColumn(ColumnName = "Id", IsPrimaryKey = true)]
        [Display(Name = "ID")]
        public string Id { get; set; }

        /// <summary>
        /// 票号
        /// </summary>
        [Display(Name = "票号")]
        public string TicketNumber { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        [Display(Name = "用户ID")]
        public int CustomerId { get; set; }

        /// <summary>
        /// 缴费金额
        /// </summary>
        [Display(Name = "缴费金额")]
        public decimal PaidFee { get; set; }

        /// <summary>
        /// 缴费时间
        /// </summary>
        [Display(Name = "缴费时间")]
        public DateTime PaidTime { get; set; }

        /// <summary>
        /// 缴费方式
        /// </summary>
        [Display(Name = "缴费方式")]
        public int PaidType { get; set; }

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

        /// <summary>
        /// 客户编号
        /// </summary>
        [Display(Name = "客户编号")]
        public string CustomerNumber { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        [Display(Name = "客户名称")]
        public string CustomerName { get; set; }
        #endregion //Property
    }
}
