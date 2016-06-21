using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// 冰块出入库窗体
    /// </summary>
    public partial class IceStockForm : BaseSingleForm
    {
        #region Field
        /// <summary>
        /// 流水类型
        /// </summary>
        private IceFlowType flowType;

        /// <summary>
        /// 冰块类型
        /// </summary>
        private IceType iceType;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 冰块出入库窗体
        /// </summary>
        /// <param name="flowType">冰块流水类型</param>
        /// <param name="iceType">冰块类型</param>
        public IceStockForm(IceFlowType flowType, IceType iceType)
        {
            InitializeComponent();

            this.flowType = flowType;
            this.iceType = iceType;
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="iceFlow"></param>
        private void SetEntity(IceFlow iceFlow)
        {
            iceFlow.FlowType = (int)this.flowType;
            iceFlow.IceType = (int)this.iceType;
            iceFlow.FlowCount = Convert.ToInt32(this.spFlowCount.Value);
            iceFlow.FlowWeight = this.spFlowWeight.Value;
            iceFlow.FlowTime = this.dpFlowTime.DateTime.Date;
            iceFlow.UserId = this.currentUser.Id;
            iceFlow.CreateTime = DateTime.Now;
            iceFlow.Remark = this.txtRemark.Text;
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IceStockForm_Load(object sender, EventArgs e)
        {
            this.Text = flowType.DisplayName();
            this.txtFlowType.Text = flowType.DisplayName();
            this.txtIceType.Text = iceType.DisplayName();
            this.txtUser.Text = this.currentUser.Name;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.spFlowCount.Value == 0)
            {
                MessageUtil.ShowInfo("流水数量为0");
                return;
            }

            IceFlow iceFlow = new IceFlow();
            SetEntity(iceFlow);

            var result = BusinessFactory<IceFlowBusiness>.Instance.Create(iceFlow);
            if (result == ErrorCode.Success)
            {
                MessageUtil.ShowInfo("添加冰块流水成功");
                this.Close();
            }
            else
            {
                MessageUtil.ShowError("添加冰块流水失败：" + result.DisplayName());
            }
        }
        #endregion //Event
    }
}
