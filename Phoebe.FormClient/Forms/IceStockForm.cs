using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Phoebe.FormClient
{
    using DevExpress.XtraEditors.Controls;
    using Phoebe.Base;
    using Phoebe.Business;
    using Phoebe.Common;
    using Phoebe.Model;

    /// <summary>
    /// 冰块操作窗体
    /// </summary>
    public partial class IceStockForm : BaseForm
    {
        #region Field
        /// <summary>
        /// 当前冰块流水ID
        /// </summary>
        private Guid currentFlowId;

        /// <summary>
        /// 界面流程状态
        /// </summary>
        private IceStockFormState formState;
        #endregion //Field

        #region Constructor
        public IceStockForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 初始化新建
        /// </summary>
        private void InitNew()
        {
            this.gpInfo.Visible = true;
            this.gpIce.Visible = true;

            this.dpTime.DateTime = DateTime.Now.Date;
            this.cmbType.SelectedIndex = -1;
            this.txtFlowNumber.Text = "";
            this.txtUser.Text = this.currentUser.Name;
            this.txtRemark.Text = "";
            this.irList.DataSource = new List<IceRecord>();

            this.dpTime.Properties.ReadOnly = false;
            this.cmbType.ReadOnly = false;
            this.txtRemark.Properties.ReadOnly = false;
            this.irList.SetEditable(true);
        }

        /// <summary>
        /// 初始化查看
        /// </summary>
        private void InitView()
        {
            if (this.currentFlowId == Guid.Empty)
                return;

            var iceFlow = BusinessFactory<IceFlowBusiness>.Instance.FindById(this.currentFlowId);
            var iceStock = BusinessFactory<IceStockBusiness>.Instance.GetByFlow(this.currentFlowId);

            this.gpInfo.Visible = true;
            this.gpIce.Visible = true;

            this.dpTime.DateTime = iceFlow.FlowTime;
            this.cmbType.SelectedIndex = (int)iceFlow.FlowType - 1;
            this.txtFlowNumber.Text = iceFlow.FlowNumber;
            this.txtUser.Text = iceFlow.User.Name;
            this.txtRemark.Text = iceFlow.Remark;


            List<IceRecord> records = new List<IceRecord>();
            IceRecord ir = new IceRecord
            {
                IceType = iceStock.IceType,
                FlowCount = iceStock.FlowCount,
                FlowWeight = iceStock.FlowWeight,
                Remark = iceStock.Remark
            };
            records.Add(ir);

            this.irList.DataSource = records;

            this.dpTime.Properties.ReadOnly = true;
            this.cmbType.ReadOnly = true;
            this.txtRemark.Properties.ReadOnly = true;
            this.irList.SetEditable(false);
        }

        /// <summary>
        /// 更新票据列表
        /// </summary>
        /// <param name="month"></param>
        private void UpdateTree(string month = "")
        {
            this.tvIce.BeginUpdate();
            this.tvIce.Nodes.Clear();

            var months = BusinessFactory<IceFlowBusiness>.Instance.GetMonthGroup();
            for (int i = 0; i < months.Length; i++)
            {
                TreeNode node = new TreeNode();
                node.Name = months[i];
                node.Text = months[i];
                node.ImageIndex = 0;
                node.Nodes.Add("");
                this.tvIce.Nodes.Add(node);
            }

            if (month != "")
            {
                var find = this.tvIce.Nodes.Find(month, false);
                if (find.Count() != 0)
                {
                    find[0].Expand();
                }
            }
            //this.lastMonth = month;
            this.tvIce.EndUpdate();
        }

        /// <summary>
        /// 更新工具栏状态
        /// </summary>
        private void UpdateToolbar()
        {
            switch (this.formState)
            {
                case IceStockFormState.Empty:
                    this.tsbNew.Enabled = true;
                    this.tsbSave.Enabled = false;
                    this.tsbDelete.Enabled = false;
                    this.tsbPrint.Enabled = false;
                    break;
                case IceStockFormState.Add:
                    this.tsbNew.Enabled = true;
                    this.tsbSave.Enabled = true;
                    this.tsbDelete.Enabled = false;
                    this.tsbPrint.Enabled = false;
                    break;
                case IceStockFormState.View:
                    this.tsbNew.Enabled = true;
                    this.tsbSave.Enabled = false;
                    this.tsbDelete.Enabled = true;
                    this.tsbPrint.Enabled = true;
                    break;
            }
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
            this.currentFlowId = Guid.Empty;
            this.formState = IceStockFormState.Empty;

            UpdateTree();
            UpdateToolbar();

            this.gpInfo.Visible = false;
            this.gpIce.Visible = false;
        }

        /// <summary>
        /// 树形菜单载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvIce_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            var data = BusinessFactory<IceFlowBusiness>.Instance.GetByMonth(e.Node.Name);
            e.Node.Nodes.Clear();
            foreach (var item in data)
            {
                TreeNode node = new TreeNode();
                node.Name = item.Id.ToString();
                node.Text = item.FlowNumber;
                node.Tag = item.FlowType;
                if (item.FlowType == (int)IceFlowType.CompleteStockIn)
                    node.ImageIndex = 1;
                else if (item.FlowType == (int)IceFlowType.FragmentStockIn)
                    node.ImageIndex = 2;
                else if (item.FlowType == (int)IceFlowType.CompleteMakeOut)
                    node.ImageIndex = 3;
                e.Node.Nodes.Add(node);
            }
        }

        /// <summary>
        /// 选择历史单据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvIce_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                e.Node.SelectedImageIndex = 0;
                return;
            }

            this.currentFlowId = new Guid(e.Node.Name);
            this.formState = IceStockFormState.View;

            InitView();
            UpdateToolbar();
        }

        /// <summary>
        /// 新建
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbNew_Click(object sender, EventArgs e)
        {
            this.formState = IceStockFormState.Add;
            UpdateToolbar();

            InitNew();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (this.cmbType.SelectedIndex == -1)
            {
                MessageUtil.ShowClaim("请选择业务类型");
                return;
            }

            this.irList.CloseEditor();

            IceFlow iceFlow = new IceFlow();
            iceFlow.FlowTime = this.dpTime.DateTime.Date;
            iceFlow.UserId = this.currentUser.Id;
            iceFlow.CreateTime = DateTime.Now;
            iceFlow.Remark = this.txtRemark.Text;

            switch (this.cmbType.SelectedIndex)
            {
                case 0:
                    iceFlow.FlowType = (int)IceFlowType.CompleteStockIn;
                    break;
                case 1:
                    iceFlow.FlowType = (int)IceFlowType.FragmentStockIn;
                    break;
                case 2:
                    iceFlow.FlowType = (int)IceFlowType.CompleteMakeOut;
                    break;
            }

            IceStock iceStock = new IceStock();
            var record = this.irList.DataSource.First();
            iceStock.IceType = record.IceType;
            iceStock.FlowCount = record.FlowCount;
            iceStock.FlowWeight = record.FlowWeight;
            iceStock.Remark = record.Remark;

            if (iceStock.FlowCount <= 0)
            {
                MessageUtil.ShowInfo("流水数量必须大于0");
                return;
            }

            var result = BusinessFactory<IceStockBusiness>.Instance.Create(iceStock, iceFlow);
            if (result == ErrorCode.Success)
            {
                MessageUtil.ShowInfo("添加冰块流水成功");

                this.currentFlowId = iceFlow.Id;
                this.formState = IceStockFormState.View;
                UpdateTree(iceFlow.MonthTime);
                UpdateToolbar();
                InitView();
            }
            else
            {
                MessageUtil.ShowError("添加冰块流水失败：" + result.DisplayName());
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (this.currentFlowId == Guid.Empty)
            {
                MessageUtil.ShowClaim("当前未选中单据");
                return;
            }

            if (MessageUtil.ConfirmYesNo("是否确认删除选中记录") == DialogResult.Yes)
            {
                var iceFlow = BusinessFactory<IceFlowBusiness>.Instance.FindById(this.currentFlowId);
                string month = iceFlow.MonthTime;

                var result = BusinessFactory<IceFlowBusiness>.Instance.Delete(iceFlow);
                if (result == ErrorCode.Success)
                {
                    MessageUtil.ShowInfo("删除冰块流水成功");

                    this.currentFlowId = Guid.Empty;
                    this.formState = IceStockFormState.Empty;

                    UpdateTree(month);
                    UpdateToolbar();

                    this.gpInfo.Visible = false;
                    this.gpIce.Visible = false;
                }
                else
                {
                    MessageUtil.ShowError("删除冰块流水失败：" + result.DisplayName());
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

        /// <summary>
        /// 业务类型选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.formState != IceStockFormState.Add)
                return;

            int type = this.cmbType.SelectedIndex;
            this.irList.Clear();
            if (type == 0 || type == 2)
            {
                IceRecord record = new IceRecord
                {
                    IceType = (int)IceType.Complete
                };
                this.irList.AddNew(record);
            }
            else if (type == 1)
            {
                IceRecord record = new IceRecord
                {
                    IceType = (int)IceType.Fragment
                };
                this.irList.AddNew(record);
            }
        }
        #endregion //Event

        /// <summary>
        /// 冰块界面模式
        /// </summary>
        internal enum IceStockFormState
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
            View = 2
        }
    }
}
