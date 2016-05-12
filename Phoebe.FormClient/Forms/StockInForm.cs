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
        /// 流程状态
        /// </summary>
        private StockInState state;

        /// <summary>
        /// 新建入库界面
        /// </summary>
        private StockInAddControl stockInAdd;
        #endregion //Field

        #region Constructor
        public StockInForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
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
            this.state = StockInState.Empty;
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
                node.Tag = item;
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
            /// 新建入库
            /// </summary>
            New = 1,

            /// <summary>
            /// 入库保存
            /// </summary>
            Saved = 2,
        }
    }
}
