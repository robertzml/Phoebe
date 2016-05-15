using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    /// 货品出库窗体
    /// </summary>
    public partial class StockOutForm : BaseForm
    {
        #region Field
        /// <summary>
        /// 当前出库单ID
        /// </summary>
        private Guid currentStockOutId;

        /// <summary>
        /// 当前出库单状态
        /// </summary>
        private EntityStatus stockOutState;

        /// <summary>
        /// 界面流程状态
        /// </summary>
        private StockOutFormState formState;

        /// <summary>
        /// 新建出库界面
        /// </summary>
        private StockOutAddControl stockOutAdd;
        #endregion //Field

        #region Constructor
        public StockOutForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 更新工具栏状态
        /// </summary>
        private void UpdateToolbar()
        {
            switch (this.stockOutState)
            {
                case EntityStatus.Empty:
                    this.tsbNew.Enabled = true;
                    this.tsbSave.Enabled = false;
                    this.tsbConfirm.Enabled = false;
                    this.tsbPrint.Enabled = false;
                    this.tsbEdit.Enabled = false;
                    this.tsbRevert.Enabled = false;
                    this.tsbDelete.Enabled = false;
                    if (this.formState == StockOutFormState.Add)
                    {
                        this.tsbSave.Enabled = true;
                    }
                    break;
                case EntityStatus.StockOutReady:
                    if (this.formState == StockOutFormState.View)
                    {
                        this.tsbNew.Enabled = true;
                        this.tsbSave.Enabled = false;
                        this.tsbConfirm.Enabled = true;
                        this.tsbPrint.Enabled = true;
                        this.tsbEdit.Enabled = true;
                        this.tsbRevert.Enabled = false;
                        this.tsbDelete.Enabled = true;
                    }
                    else if (this.formState == StockOutFormState.Edit)
                    {
                        this.tsbNew.Enabled = true;
                        this.tsbSave.Enabled = true;
                        this.tsbConfirm.Enabled = false;
                        this.tsbPrint.Enabled = false;
                        this.tsbEdit.Enabled = false;
                        this.tsbRevert.Enabled = false;
                        this.tsbDelete.Enabled = false;
                    }
                    break;
                case EntityStatus.StockOut:
                    this.tsbNew.Enabled = true;
                    this.tsbSave.Enabled = false;
                    this.tsbConfirm.Enabled = false;
                    this.tsbPrint.Enabled = true;
                    this.tsbEdit.Enabled = false;
                    this.tsbRevert.Enabled = true;
                    this.tsbDelete.Enabled = false;
                    break;
            }
        }

        /// <summary>
        /// 更新票据列表
        /// </summary>
        private void UpdateTree()
        {
            this.tvStockOut.BeginUpdate();
            this.tvStockOut.Nodes.Clear();

            var months = BusinessFactory<StockInBusiness>.Instance.GetStockInMonthGroup();
            for (int i = 0; i < months.Length; i++)
            {
                TreeNode node = new TreeNode();
                node.Name = months[i];
                node.Text = months[i];
                node.ImageIndex = 1;
                node.Nodes.Add("");
                this.tvStockOut.Nodes.Add(node);
            }
            this.tvStockOut.EndUpdate();
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StockOutForm_Load(object sender, EventArgs e)
        {
            this.currentStockOutId = Guid.Empty;
            this.stockOutState = EntityStatus.Empty;
            this.formState = StockOutFormState.Empty;

            UpdateTree();
            UpdateToolbar();
        }

        /// <summary>
        /// 新建出库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbNew_Click(object sender, EventArgs e)
        {
            this.currentStockOutId = Guid.Empty;
            this.stockOutState = EntityStatus.Empty;
            this.formState = StockOutFormState.Add;

            UpdateToolbar();

            this.stockOutAdd = new StockOutAddControl(this.currentUser);
            ChildFormManage.LoadContentControl(this.plBody, this.stockOutAdd);
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.currentStockOutId = Guid.Empty;
            this.stockOutState = EntityStatus.Empty;
            this.formState = StockOutFormState.Empty;

            UpdateToolbar();
            ChildFormManage.LoadContentControl(this.plBody, this.plEmpty);
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (this.formState == StockOutFormState.Add) //保存新建
            {
                string errorMessage;
                Guid newId;
                ErrorCode result = this.stockOutAdd.Save(out errorMessage, out newId);
                if (result == ErrorCode.Success)
                {
                    MessageBox.Show("保存出库成功", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.currentStockOutId = newId;
                    this.stockOutState = EntityStatus.StockInReady;
                    this.formState = StockOutFormState.View;

                    UpdateTree();
                    UpdateToolbar();

                    //this.stockInView = new StockInViewControl(this.currentStockInId);
                    //ChildFormManage.LoadContentControl(this.plBody, this.stockInView);
                }
                else
                {
                    MessageBox.Show("保存出库失败，" + result.DisplayName() + "， " + errorMessage, FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// 出库确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbConfirm_Click(object sender, EventArgs e)
        {

        }
        #endregion //Event

        /// <summary>
        /// 出库界面模式
        /// </summary>
        internal enum StockOutFormState
        {
            /// <summary>
            /// 空
            /// </summary>
            Empty = 0,

            /// <summary>
            /// 新增模式
            /// </summary>
            Add = 1,

            /// <summary>
            /// 查看模式
            /// </summary>
            View = 2,

            /// <summary>
            /// 编辑模式
            /// </summary>
            Edit = 3
        }

    }
}
