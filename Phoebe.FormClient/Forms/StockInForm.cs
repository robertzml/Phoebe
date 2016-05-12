using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        /// 界面流程状态
        /// </summary>
        private StockInState state;

        /// <summary>
        /// 当前入库单状态
        /// </summary>
        private EntityStatus stockInState;

        /// <summary>
        /// 新建入库界面
        /// </summary>
        private StockInAddControl stockInAdd;

        /// <summary>
        /// 入库单查询界面
        /// </summary>
        private StockInViewControl stockInView;
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
                    this.tsbSave.Enabled = true;
                    this.tsbConfirm.Enabled = false;
                    this.tsbPrint.Enabled = false;
                    this.tsbEdit.Enabled = false;
                    this.tsbRevert.Enabled = false;
                    this.tsbDelete.Enabled = false;
                    break;
            }
        }

        /// <summary>
        /// 更新票据列表
        /// </summary>
        private void UpdateTree()
        {
            this.tvStockIn.Nodes.Clear();

            var months = BusinessFactory<StockInBusiness>.Instance.GetStockInMonthGroup();
            for (int i = 0; i < months.Length; i++)
            {
                TreeNode node = new TreeNode();
                node.Name = months[i];
                node.Text = months[i];
                node.ImageIndex = 1;
                node.Nodes.Add("");
                this.tvStockIn.Nodes.Add(node);
            }
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
            this.state = StockInState.Empty;
            this.stockInState = EntityStatus.Empty;
            UpdateTree();
        }

        /// <summary>
        /// 树形菜单载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvStockIn_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            var data = BusinessFactory<StockInBusiness>.Instance.GetStockInByMonth(e.Node.Name);
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

            this.state = StockInState.Open;
            this.currentStockInId = new Guid(e.Node.Name);
            this.stockInState = (EntityStatus)e.Node.Tag;
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
            this.state = StockInState.New;
            this.stockInAdd = new StockInAddControl(this.currentUser);
            ChildFormManage.LoadContentControl(this.plBody, this.stockInAdd);
        }

        /// <summary>
        /// 保存入库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbSave_Click(object sender, EventArgs e)
        {
            string errorMessage;
            ErrorCode result = this.stockInAdd.Save(out errorMessage);
            if (result == ErrorCode.Success)
            {
                this.state = StockInState.Saved;
                MessageBox.Show("保存入库成功", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("保存入库失败，" + result.DisplayName() + ", " + errorMessage, FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

            ErrorCode result = BusinessFactory<StockInBusiness>.Instance.Delete(this.currentStockInId);
            if (result == ErrorCode.Success)
            {
                this.state = StockInState.Empty;
                MessageBox.Show("删除入库成功", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.plBody.Controls.Clear();
            }
            else
            {
                MessageBox.Show("删除入库失败，" + result.DisplayName(), FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion //Event

        /// <summary>
        /// 入库界面流程状态
        /// </summary>
        internal enum StockInState
        {
            /// <summary>
            /// 初始化
            /// </summary>
            Empty = 0,

            /// <summary>
            /// 选择入库
            /// </summary>
            Open = 1,

            /// <summary>
            /// 新建入库
            /// </summary>
            New = 2,

            /// <summary>
            /// 入库保存
            /// </summary>
            Saved = 3,
        }
    }
}
