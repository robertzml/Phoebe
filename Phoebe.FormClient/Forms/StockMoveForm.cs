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
    /// 货品移库窗体
    /// </summary>
    public partial class StockMoveForm : BaseForm
    {
        #region Field
        /// <summary>
        /// 当前移库单ID
        /// </summary>
        private Guid currentStockMoveId;

        /// <summary>
        /// 当前移库单状态
        /// </summary>
        private EntityStatus stockMoveState;

        /// <summary>
        /// 界面流程状态
        /// </summary>
        private StockMoveFormState formState;

        /// <summary>
        /// 新建移库界面
        /// </summary>
        private StockMoveAddControl stockMoveAdd;

        /// <summary>
        /// 查看移库界面
        /// </summary>
        private StockMoveViewControl stockMoveView;

        /// <summary>
        /// 最新选择树形节点
        /// </summary>
        private string lastMonth = "";
        #endregion //Field

        #region Constructor
        public StockMoveForm()
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
            switch (this.stockMoveState)
            {
                case EntityStatus.Empty:
                    this.tsbNew.Enabled = true;
                    this.tsbSave.Enabled = false;
                    this.tsbConfirm.Enabled = false;
                    this.tsbPrint.Enabled = false;
                    this.tsbEdit.Enabled = false;
                    this.tsbRevert.Enabled = false;
                    this.tsbDelete.Enabled = false;
                    if (this.formState == StockMoveFormState.Add)
                    {
                        this.tsbSave.Enabled = true;
                    }
                    break;
                case EntityStatus.StockMoveReady:
                    if (this.formState == StockMoveFormState.View)
                    {
                        this.tsbNew.Enabled = true;
                        this.tsbSave.Enabled = false;
                        this.tsbConfirm.Enabled = true;
                        this.tsbPrint.Enabled = true;
                        this.tsbEdit.Enabled = true;
                        this.tsbRevert.Enabled = false;
                        this.tsbDelete.Enabled = true;
                    }
                    else if (this.formState == StockMoveFormState.Edit)
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
                case EntityStatus.StockMove:
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
            this.tvStockMove.BeginUpdate();
            this.tvStockMove.Nodes.Clear();

            var months = BusinessFactory<StockMoveBusiness>.Instance.GetMonthGroup();
            for (int i = 0; i < months.Length; i++)
            {
                TreeNode node = new TreeNode();
                node.Name = months[i];
                node.Text = months[i];
                node.ImageIndex = 1;
                node.Nodes.Add("");
                this.tvStockMove.Nodes.Add(node);
            }

            if (month != "")
            {
                var find = this.tvStockMove.Nodes.Find(month, false);
                if (find.Count() != 0)
                {
                    find[0].Expand();
                }
            }
            this.tvStockMove.EndUpdate();
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StockMoveForm_Load(object sender, EventArgs e)
        {
            this.currentStockMoveId = Guid.Empty;
            this.stockMoveState = EntityStatus.Empty;
            this.formState = StockMoveFormState.Empty;

            UpdateTree();
            UpdateToolbar();
        }

        /// <summary>
        /// 树形菜单载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvStockMove_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            var data = BusinessFactory<StockMoveBusiness>.Instance.GetByMonth(e.Node.Name);
            e.Node.Nodes.Clear();
            foreach (var item in data)
            {
                TreeNode node = new TreeNode();
                node.Name = item.Id.ToString();
                node.Text = item.FlowNumber;
                node.Tag = item.Status;
                if (item.Status == (int)EntityStatus.StockMoveReady)
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
        private void tvStockMove_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                e.Node.SelectedImageIndex = 1;
                return;
            }

            this.lastMonth = e.Node.Parent.Text;
            this.currentStockMoveId = new Guid(e.Node.Name);
            this.stockMoveState = (EntityStatus)e.Node.Tag;
            this.formState = StockMoveFormState.View;

            UpdateToolbar();

            this.stockMoveView = new StockMoveViewControl(this.currentStockMoveId);
            ChildFormManage.LoadContentControl(this.plBody, this.stockMoveView);
        }

        /// <summary>
        /// 新建移库单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbNew_Click(object sender, EventArgs e)
        {
            this.currentStockMoveId = Guid.Empty;
            this.stockMoveState = EntityStatus.Empty;
            this.formState = StockMoveFormState.Add;

            UpdateToolbar();

            this.stockMoveAdd = new StockMoveAddControl(this.currentUser);
            ChildFormManage.LoadContentControl(this.plBody, this.stockMoveAdd);
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.currentStockMoveId = Guid.Empty;
            this.stockMoveState = EntityStatus.Empty;
            this.formState = StockMoveFormState.Empty;

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
            if (this.formState == StockMoveFormState.Add) //保存新建
            {
                string errorMessage, month;
                Guid newId;
                ErrorCode result = this.stockMoveAdd.Save(out errorMessage, out newId, out month);
                if (result == ErrorCode.Success)
                {
                    MessageBox.Show("保存移库成功", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.currentStockMoveId = newId;
                    this.stockMoveState = EntityStatus.StockMoveReady;
                    this.formState = StockMoveFormState.View;

                    UpdateTree(month);
                    UpdateToolbar();

                    this.stockMoveView = new StockMoveViewControl(this.currentStockMoveId);
                    ChildFormManage.LoadContentControl(this.plBody, this.stockMoveView);
                }
                else
                {
                    MessageBox.Show("保存移库失败，" + result.DisplayName() + "， " + errorMessage, FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// 移库确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbConfirm_Click(object sender, EventArgs e)
        {
            if (this.currentStockMoveId == Guid.Empty)
            {
                MessageBox.Show("当前未选中移库单", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.stockMoveState != EntityStatus.StockMoveReady)
            {
                MessageBox.Show("当前移库已确认", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ErrorCode result = BusinessFactory<StockMoveBusiness>.Instance.Confirm(this.currentStockMoveId);
            if (result == ErrorCode.Success)
            {
                MessageBox.Show("移库确认成功", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.stockMoveState = EntityStatus.StockMove;
                this.formState = StockMoveFormState.View;

                UpdateTree(this.lastMonth);
                UpdateToolbar();
            }
            else
            {
                MessageBox.Show("移库确认失败，" + result.DisplayName(), FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbEdit_Click(object sender, EventArgs e)
        {

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
        /// 移库界面模式
        /// </summary>
        internal enum StockMoveFormState
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
