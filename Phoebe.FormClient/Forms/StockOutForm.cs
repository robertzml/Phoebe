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

        /// <summary>
        /// 查看出库界面
        /// </summary>
        private StockOutViewControl stockOutView;

        /// <summary>
        /// 编辑出库界面
        /// </summary>
        private StockOutEditControl stockOutEdit;

        /// <summary>
        /// 最新选择树形节点
        /// </summary>
        private string lastMonth = "";
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
        private void UpdateTree(string month = "")
        {
            this.tvStockOut.BeginUpdate();
            this.tvStockOut.Nodes.Clear();

            var months = BusinessFactory<StockOutBusiness>.Instance.GetMonthGroup();
            for (int i = 0; i < months.Length; i++)
            {
                TreeNode node = new TreeNode();
                node.Name = months[i];
                node.Text = months[i];
                node.ImageIndex = 1;
                node.Nodes.Add("");
                this.tvStockOut.Nodes.Add(node);
            }

            if (month != "")
            {
                var find = this.tvStockOut.Nodes.Find(month, false);
                if (find.Count() != 0)
                {
                    find[0].Expand();
                }
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
        /// 树形菜单载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvStockOut_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            var data = BusinessFactory<StockOutBusiness>.Instance.GetByMonth(e.Node.Name);
            e.Node.Nodes.Clear();
            foreach (var item in data)
            {
                TreeNode node = new TreeNode();
                node.Name = item.Id.ToString();
                node.Text = item.FlowNumber;
                node.Tag = item.Status;
                if (item.Status == (int)EntityStatus.StockOutReady)
                    node.ImageIndex = 2;
                else
                    node.ImageIndex = 3;
                e.Node.Nodes.Add(node);
            }
        }

        /// <summary>
        /// 选择历史单据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvStockOut_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                e.Node.SelectedImageIndex = 1;
                return;
            }

            this.lastMonth = e.Node.Parent.Text;
            this.currentStockOutId = new Guid(e.Node.Name);
            this.stockOutState = (EntityStatus)e.Node.Tag;
            this.formState = StockOutFormState.View;

            UpdateToolbar();

            this.stockOutView = new StockOutViewControl(this.currentStockOutId);
            ChildFormManage.LoadContentControl(this.plBody, this.stockOutView);
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
                string errorMessage, month;
                Guid newId;
                ErrorCode result = this.stockOutAdd.Save(out errorMessage, out newId, out month);
                if (result == ErrorCode.Success)
                {
                    MessageBox.Show("保存出库成功", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.currentStockOutId = newId;
                    this.stockOutState = EntityStatus.StockOutReady;
                    this.formState = StockOutFormState.View;

                    UpdateTree(month);
                    UpdateToolbar();

                    this.stockOutView = new StockOutViewControl(this.currentStockOutId);
                    ChildFormManage.LoadContentControl(this.plBody, this.stockOutView);
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
            if (this.currentStockOutId == Guid.Empty)
            {
                MessageBox.Show("当前未选中出库单", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.stockOutState != EntityStatus.StockOutReady)
            {
                MessageBox.Show("当前出库已确认", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ErrorCode result = BusinessFactory<StockOutBusiness>.Instance.Confirm(this.currentStockOutId);
            if (result == ErrorCode.Success)
            {
                MessageBox.Show("出库确认成功", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.stockOutState = EntityStatus.StockOut;
                this.formState = StockOutFormState.View;

                UpdateTree(this.lastMonth);
                UpdateToolbar();
            }
            else
            {
                MessageBox.Show("出库确认失败，" + result.DisplayName(), FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbEdit_Click(object sender, EventArgs e)
        {
            if (this.currentStockOutId == Guid.Empty)
            {
                MessageBox.Show("当前未选中出库单", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.stockOutState != EntityStatus.StockOutReady)
            {
                MessageBox.Show("出库已确认，无法编辑", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.formState = StockOutFormState.Edit;
            UpdateToolbar();

            this.stockOutEdit = new StockOutEditControl(this.currentStockOutId);
            ChildFormManage.LoadContentControl(this.plBody, this.stockOutEdit);
        }

        /// <summary>
        /// 撤回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbRevert_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (this.currentStockOutId == Guid.Empty)
            {
                MessageBox.Show("当前未选中出库单", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.stockOutState != EntityStatus.StockOutReady)
            {
                MessageBox.Show("出库已确认，无法删除", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dr = MessageBox.Show("是否确认删除选中记录", FormConstant.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                ErrorCode result = BusinessFactory<StockOutBusiness>.Instance.Delete(this.currentStockOutId);
                if (result == ErrorCode.Success)
                {
                    MessageBox.Show("删除出库成功", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.currentStockOutId = Guid.Empty;
                    this.stockOutState = EntityStatus.Empty;
                    this.formState = StockOutFormState.Empty;

                    ChildFormManage.LoadContentControl(this.plBody, this.plEmpty);
                    UpdateTree(this.lastMonth);
                    UpdateToolbar();
                }
                else
                {
                    MessageBox.Show("删除出库失败，" + result.DisplayName(), FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbPrint_Click(object sender, EventArgs e)
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
