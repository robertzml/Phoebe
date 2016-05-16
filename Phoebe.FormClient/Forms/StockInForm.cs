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
    /// 货品入库窗体
    /// </summary>
    public partial class StockInForm : BaseForm
    {
        #region Field
        /// <summary>
        /// 当前入库单ID
        /// </summary>
        private Guid currentStockInId;

        /// <summary>
        /// 当前入库单状态
        /// </summary>
        private EntityStatus stockInState;

        /// <summary>
        /// 界面流程状态
        /// </summary>
        private StockInFormState formState;

        /// <summary>
        /// 入库单查询界面
        /// </summary>
        private StockInViewControl stockInView;

        /// <summary>
        /// 新建入库界面
        /// </summary>
        private StockInAddControl stockInAdd;

        /// <summary>
        /// 编辑入库界面
        /// </summary>
        private StockInEditControl stockInEdit;

        /// <summary>
        /// 最新选择树形节点
        /// </summary>
        private string lastMonth = "";
        #endregion //Field

        #region Constructor
        public StockInForm()
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
            switch (this.stockInState)
            {
                case EntityStatus.Empty:
                    this.tsbNew.Enabled = true;
                    this.tsbSave.Enabled = false;
                    this.tsbConfirm.Enabled = false;
                    this.tsbPrint.Enabled = false;
                    this.tsbEdit.Enabled = false;
                    this.tsbRevert.Enabled = false;
                    this.tsbDelete.Enabled = false;
                    if (this.formState == StockInFormState.Add)
                    {
                        this.tsbSave.Enabled = true;
                    }
                    break;
                case EntityStatus.StockInReady:
                    if (this.formState == StockInFormState.View)
                    {
                        this.tsbNew.Enabled = true;
                        this.tsbSave.Enabled = false;
                        this.tsbConfirm.Enabled = true;
                        this.tsbPrint.Enabled = true;
                        this.tsbEdit.Enabled = true;
                        this.tsbRevert.Enabled = false;
                        this.tsbDelete.Enabled = true;
                    }
                    else if (this.formState == StockInFormState.Edit)
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
                case EntityStatus.StockIn:
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
        /// <param name="month">打开节点</param>
        private void UpdateTree(string month = "")
        {
            this.tvStockIn.BeginUpdate();
            this.tvStockIn.Nodes.Clear();

            var months = BusinessFactory<StockInBusiness>.Instance.GetMonthGroup();
            for (int i = 0; i < months.Length; i++)
            {
                TreeNode node = new TreeNode();
                node.Name = months[i];
                node.Text = months[i];
                node.ImageIndex = 1;
                node.Nodes.Add("");
                this.tvStockIn.Nodes.Add(node);
            }

            if (month != "")
            {
                var find = this.tvStockIn.Nodes.Find(month, false);
                if (find.Count() != 0)
                {
                    find[0].Expand();
                }
            }
            this.tvStockIn.EndUpdate();
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StockInForm_Load(object sender, EventArgs e)
        {
            this.currentStockInId = Guid.Empty;
            this.stockInState = EntityStatus.Empty;
            this.formState = StockInFormState.Empty;

            UpdateTree();
            UpdateToolbar();
        }

        /// <summary>
        /// 树形菜单载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvStockIn_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            var data = BusinessFactory<StockInBusiness>.Instance.GetByMonth(e.Node.Name);
            e.Node.Nodes.Clear();
            foreach (var item in data)
            {
                TreeNode node = new TreeNode();
                node.Name = item.Id.ToString();
                node.Text = item.FlowNumber;
                node.Tag = item.Status;
                if (item.Status == (int)EntityStatus.StockInReady)
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
        private void tvStockIn_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                e.Node.SelectedImageIndex = 1;
                return;
            }

            this.lastMonth = e.Node.Parent.Text;
            this.currentStockInId = new Guid(e.Node.Name);
            this.stockInState = (EntityStatus)e.Node.Tag;
            this.formState = StockInFormState.View;

            UpdateToolbar();

            this.stockInView = new StockInViewControl(this.currentStockInId);
            ChildFormManage.LoadContentControl(this.plBody, this.stockInView);
        }

        /// <summary>
        /// 新建入库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbNew_Click(object sender, EventArgs e)
        {
            this.currentStockInId = Guid.Empty;
            this.stockInState = EntityStatus.Empty;
            this.formState = StockInFormState.Add;

            UpdateToolbar();

            this.stockInAdd = new StockInAddControl(this.currentUser);
            ChildFormManage.LoadContentControl(this.plBody, this.stockInAdd);
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.currentStockInId = Guid.Empty;
            this.stockInState = EntityStatus.Empty;
            this.formState = StockInFormState.Empty;

            UpdateToolbar();
            ChildFormManage.LoadContentControl(this.plBody, this.plEmpty);
        }

        /// <summary>
        /// 保存入库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (this.formState == StockInFormState.Add) //保存新建
            {
                string errorMessage, month;
                Guid newId;
                ErrorCode result = this.stockInAdd.Save(out errorMessage, out newId, out month);
                if (result == ErrorCode.Success)
                {
                    MessageBox.Show("保存入库成功", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.currentStockInId = newId;
                    this.stockInState = EntityStatus.StockInReady;
                    this.formState = StockInFormState.View;

                    UpdateTree(month);
                    UpdateToolbar();

                    this.stockInView = new StockInViewControl(this.currentStockInId);
                    ChildFormManage.LoadContentControl(this.plBody, this.stockInView);
                }
                else
                {
                    MessageBox.Show("保存入库失败，" + result.DisplayName() + "， " + errorMessage, FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (this.formState == StockInFormState.Edit) //保存修改
            {
                if (this.currentStockInId == Guid.Empty)
                {
                    MessageBox.Show("当前未选中入库单", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (this.stockInState != EntityStatus.StockInReady)
                {
                    MessageBox.Show("当前入库已确认，无法保存", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string errorMessage;
                ErrorCode result = this.stockInEdit.Save(out errorMessage);
                if (result == ErrorCode.Success)
                {
                    MessageBox.Show("保存入库成功", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.stockInState = EntityStatus.StockInReady;
                    this.formState = StockInFormState.View;

                    UpdateToolbar();

                    this.stockInView = new StockInViewControl(this.currentStockInId);
                    ChildFormManage.LoadContentControl(this.plBody, this.stockInView);
                }
                else
                {
                    MessageBox.Show("保存入库失败，" + result.DisplayName() + "， " + errorMessage, FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// 入库确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbConfirm_Click(object sender, EventArgs e)
        {
            if (this.currentStockInId == Guid.Empty)
            {
                MessageBox.Show("当前未选中入库单", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.stockInState != EntityStatus.StockInReady)
            {
                MessageBox.Show("当前入库已确认", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ErrorCode result = BusinessFactory<StockInBusiness>.Instance.Confirm(this.currentStockInId);
            if (result == ErrorCode.Success)
            {
                MessageBox.Show("入库确认成功", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.stockInState = EntityStatus.StockIn;
                this.formState = StockInFormState.View;

                UpdateTree(this.lastMonth);
                UpdateToolbar();
            }
            else
            {
                MessageBox.Show("入库确认失败，" + result.DisplayName(), FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbEdit_Click(object sender, EventArgs e)
        {
            if (this.currentStockInId == Guid.Empty)
            {
                MessageBox.Show("当前未选中入库单", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.stockInState != EntityStatus.StockInReady)
            {
                MessageBox.Show("当前入库已确认，无法编辑", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.formState = StockInFormState.Edit;
            UpdateToolbar();

            this.stockInEdit = new StockInEditControl(this.currentStockInId);
            ChildFormManage.LoadContentControl(this.plBody, this.stockInEdit);
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
        /// 删除入库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (this.currentStockInId == Guid.Empty)
            {
                MessageBox.Show("当前未选中入库单", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.stockInState != EntityStatus.StockInReady)
            {
                MessageBox.Show("入库已确认，无法删除", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dr = MessageBox.Show("是否确认删除选中记录", FormConstant.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                ErrorCode result = BusinessFactory<StockInBusiness>.Instance.Delete(this.currentStockInId);
                if (result == ErrorCode.Success)
                {
                    MessageBox.Show("删除入库成功", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.currentStockInId = Guid.Empty;
                    this.stockInState = EntityStatus.Empty;
                    this.formState = StockInFormState.Empty;

                    ChildFormManage.LoadContentControl(this.plBody, this.plEmpty);
                    UpdateTree(this.lastMonth);
                    UpdateToolbar();
                }
                else
                {
                    MessageBox.Show("删除入库失败，" + result.DisplayName(), FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        /// 入库界面模式
        /// </summary>
        internal enum StockInFormState
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
