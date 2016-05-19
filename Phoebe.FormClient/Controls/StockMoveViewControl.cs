using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Phoebe.FormClient
{
    using Phoebe.Base;
    using Phoebe.Business;
    using Phoebe.Common;
    using Phoebe.Model;

    /// <summary>
    /// 移库查看控件
    /// </summary>
    public partial class StockMoveViewControl : UserControl
    {
        #region Field
        /// <summary>
        /// 关联移库单
        /// </summary>
        private StockMove stockMove;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 移库查看控件
        /// </summary>
        /// <param name="stockMoveId">移库单ID</param>
        public StockMoveViewControl(Guid stockMoveId)
        {
            InitializeComponent();

            this.stockMove = BusinessFactory<StockMoveBusiness>.Instance.FindById(stockMoveId);

            SetBaseControl(stockMove);
            SetDataControl(stockMove);
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 设置基本信息
        /// </summary>
        /// <param name="stockMove">移库单对象</param>
        private void SetBaseControl(StockMove stockMove)
        {
            this.txtStatus.Text = ((EntityStatus)stockMove.Status).DisplayName();
            this.txtMoveTime.Text = stockMove.MoveTime.ToShortDateString();
            this.txtUser.Text = stockMove.User.Name;
            this.txtCustomerNumber.Text = stockMove.Contract.Customer.Number;
            this.txtCustomerName.Text = stockMove.Contract.Customer.Name;
            this.txtContract.Text = stockMove.Contract.Name;
            this.txtBillingType.Text = ((BillingType)stockMove.Contract.BillingType).DisplayName();
            this.txtRemark.Text = stockMove.Remark;
            this.txtFlowNumber.Text = stockMove.FlowNumber;
            this.txtCreateTime.Text = stockMove.CreateTime.ToDateTimeString();
        }

        /// <summary>
        /// 设置移库数据信息
        /// </summary>
        /// <param name="stockOut">移库单对象</param>
        private void SetDataControl(StockMove stockMove)
        {
            var data = ModelTranslate.StockMoveToModel(stockMove);
            this.smgList.DataSource = data;
        }
        #endregion //Function
    }
}
