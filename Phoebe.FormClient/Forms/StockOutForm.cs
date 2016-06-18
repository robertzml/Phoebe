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
    using DevExpress.XtraReports.UI;
    using DevExpress.XtraEditors.Controls;
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
        /// <param name="month">打开节点</param>
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
            this.lastMonth = month;
            this.tvStockOut.EndUpdate();
        }

        /// <summary>
        /// 更新合同列表
        /// </summary>
        /// <param name="customerId">客户Id</param>
        private void UpdateContractList(int customerId)
        {
            var contracts = BusinessFactory<ContractBusiness>.Instance.GetByCustomer(customerId);

            this.cmbContract.Properties.Items.Clear();

            ImageComboBoxItem empty = new ImageComboBoxItem();
            empty.Description = "--全部合同--";
            empty.Value = 0;
            this.cmbContract.Properties.Items.Add(empty);

            foreach (var item in contracts)
            {
                ImageComboBoxItem i = new ImageComboBoxItem();
                i.Description = item.Name;
                i.Value = item.Id;

                this.cmbContract.Properties.Items.Add(i);
            }

            this.cmbContract.EditValue = 0;
        }
        #endregion //Function

        #region Event
        #region Control Event
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

            this.bsCustomer.DataSource = BusinessFactory<CustomerBusiness>.Instance.FindAll();
            this.lkuCustomer.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(EventUtil.LkuCustomer_CustomDisplayText);
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
        /// 客户选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lkuCustomer_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lkuCustomer.EditValue == null)
                UpdateContractList(0);
            else
                UpdateContractList(Convert.ToInt32(this.lkuCustomer.EditValue));
        }

        /// <summary>
        /// 搜索出库单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.lkuCustomer.EditValue == null)
            {
                MessageUtil.ShowClaim("请选择客户");
                return;
            }

            List<StockOut> data;
            if (this.cmbContract.EditValue != null && Convert.ToInt32(this.cmbContract.EditValue) != 0)
            {
                data = BusinessFactory<StockOutBusiness>.Instance.GetByContract((int)this.cmbContract.EditValue);
            }
            else
            {
                data = BusinessFactory<StockOutBusiness>.Instance.GetByCustomer((int)this.lkuCustomer.EditValue);
            }

            this.lbStockOut.Items.Clear();
            foreach (var item in data)
            {
                ImageListBoxItem i = new ImageListBoxItem();
                i.Description = item.FlowNumber;
                i.Value = item.Id.ToString();
                if (item.Status == (int)EntityStatus.StockOutReady)
                    i.ImageIndex = 2;
                else
                    i.ImageIndex = 3;

                this.lbStockOut.Items.Add(i);
            }
        }

        /// <summary>
        /// 选择搜索单据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbStockOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lbStockOut.SelectedItem == null)
                return;

            var id = new Guid(this.lbStockOut.SelectedValue.ToString());

            var stockOut = BusinessFactory<StockOutBusiness>.Instance.FindById(id);
            if (stockOut == null)
            {
                MessageUtil.ShowInfo("该出库单已删除");
                return;
            }

            this.currentStockOutId = stockOut.Id;
            this.stockOutState = (EntityStatus)stockOut.Status;
            this.formState = StockOutFormState.View;

            UpdateToolbar();

            this.stockOutView = new StockOutViewControl(this.currentStockOutId);
            ChildFormManage.LoadContentControl(this.plBody, this.stockOutView);
        }
        #endregion //Control Event

        #region Toolbar Event
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
                    MessageUtil.ShowInfo("保存出库成功");

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
                    MessageUtil.ShowWarning("保存出库失败，" + result.DisplayName() + "， " + errorMessage);
                }
            }
            else if (this.formState == StockOutFormState.Edit) //保存修改
            {
                if (this.currentStockOutId == Guid.Empty)
                {
                    MessageUtil.ShowClaim("当前未选中出库单");
                    return;
                }

                if (this.stockOutState != EntityStatus.StockOutReady)
                {
                    MessageUtil.ShowClaim("当前出库已确认，无法保存");
                    return;
                }

                string errorMessage;
                ErrorCode result = this.stockOutEdit.Save(out errorMessage);
                if (result == ErrorCode.Success)
                {
                    MessageUtil.ShowInfo("保存出库成功");

                    this.stockOutState = EntityStatus.StockOutReady;
                    this.formState = StockOutFormState.View;

                    UpdateToolbar();

                    this.stockOutView = new StockOutViewControl(this.currentStockOutId);
                    ChildFormManage.LoadContentControl(this.plBody, this.stockOutView);
                }
                else
                {
                    MessageUtil.ShowWarning("保存出库失败，" + result.DisplayName() + "， " + errorMessage);
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
                MessageUtil.ShowClaim("当前未选中出库单");
                return;
            }

            if (this.stockOutState != EntityStatus.StockOutReady)
            {
                MessageUtil.ShowClaim("当前出库已确认");
                return;
            }

            ErrorCode result = BusinessFactory<StockOutBusiness>.Instance.Confirm(this.currentStockOutId);
            if (result == ErrorCode.Success)
            {
                MessageUtil.ShowInfo("出库确认成功");

                this.stockOutState = EntityStatus.StockOut;
                this.formState = StockOutFormState.View;

                UpdateTree(this.lastMonth);
                UpdateToolbar();
            }
            else
            {
                MessageUtil.ShowWarning("出库确认失败，" + result.DisplayName());
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
                MessageUtil.ShowClaim("当前未选中出库单");
                return;
            }

            if (this.stockOutState != EntityStatus.StockOutReady)
            {
                MessageUtil.ShowClaim("出库已确认，无法编辑");
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
            if (this.currentStockOutId == Guid.Empty)
            {
                MessageUtil.ShowClaim("当前未选中出库单");
                return;
            }

            if (this.stockOutState != EntityStatus.StockOut)
            {
                MessageUtil.ShowClaim("当前出库未确认，无法撤回");
                return;
            }

            if (MessageUtil.ConfirmYesNo("是否确认撤回选中记录") == DialogResult.Yes)
            {
                ErrorCode result = BusinessFactory<StockOutBusiness>.Instance.Revert(this.currentStockOutId);
                if (result == ErrorCode.Success)
                {
                    MessageUtil.ShowInfo("撤回出库成功");

                    this.stockOutState = EntityStatus.StockOutReady;
                    this.formState = StockOutFormState.View;

                    UpdateTree(this.lastMonth);
                    UpdateToolbar();
                }
                else
                {
                    MessageUtil.ShowWarning("撤回出库失败，" + result.DisplayName());
                }
            }
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
                MessageUtil.ShowClaim("当前未选中出库单");
                return;
            }

            if (this.stockOutState != EntityStatus.StockOutReady)
            {
                MessageUtil.ShowClaim("出库已确认，无法删除");
                return;
            }

            if (MessageUtil.ConfirmYesNo("是否确认删除选中记录") == DialogResult.Yes)
            {
                ErrorCode result = BusinessFactory<StockOutBusiness>.Instance.Delete(this.currentStockOutId);
                if (result == ErrorCode.Success)
                {
                    MessageUtil.ShowInfo("删除出库成功");

                    this.currentStockOutId = Guid.Empty;
                    this.stockOutState = EntityStatus.Empty;
                    this.formState = StockOutFormState.Empty;

                    ChildFormManage.LoadContentControl(this.plBody, this.plEmpty);
                    UpdateTree(this.lastMonth);
                    UpdateToolbar();
                }
                else
                {
                    MessageUtil.ShowWarning("删除出库失败：" + result.DisplayName());
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
            if (this.currentStockOutId == Guid.Empty)
            {
                MessageUtil.ShowClaim("当前未选中出库单");
                return;
            }

            var stockOut = BusinessFactory<StockOutBusiness>.Instance.FindById(this.currentStockOutId);
            var model = ModelTranslate.StockOutToReport(stockOut);

            Report.StockOut report = new Report.StockOut(model);

            ReportPrintTool tool = new ReportPrintTool(report);
            tool.ShowPreview();
        }
        #endregion //Toolbar Event
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
