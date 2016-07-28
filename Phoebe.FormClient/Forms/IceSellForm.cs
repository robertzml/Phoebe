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
    using DevExpress.XtraEditors.Controls;
    using Phoebe.Base;
    using Phoebe.Business;
    using Phoebe.Common;
    using Phoebe.Model;

    /// <summary>
    /// 冰块售出窗体
    /// </summary>
    public partial class IceSellForm : BaseForm
    {
        #region Field
        /// <summary>
        /// 当前冰块流水ID
        /// </summary>
        private Guid currentFlowId;

        /// <summary>
        /// 界面流程状态
        /// </summary>
        private IceSellFormState formState;
        #endregion //Field

        #region Constructor
        public IceSellForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 更新票据列表
        /// </summary>
        /// <param name="month"></param>
        private void UpdateTree(string month = "")
        {
            this.tvIce.BeginUpdate();
            this.tvIce.Nodes.Clear();

            var months = BusinessFactory<IceFlowBusiness>.Instance.GetSaleMonthGroup();
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
            this.tvIce.EndUpdate();
        }

        /// <summary>
        /// 更新工具栏状态
        /// </summary>
        private void UpdateToolbar()
        {
            switch (this.formState)
            {
                case IceSellFormState.Empty:
                    this.tsbNew.Enabled = true;
                    this.tsbSave.Enabled = false;
                    this.tsbDelete.Enabled = false;
                    this.tsbPrint.Enabled = false;
                    break;
                case IceSellFormState.Add:
                    this.tsbNew.Enabled = true;
                    this.tsbSave.Enabled = true;
                    this.tsbDelete.Enabled = false;
                    this.tsbPrint.Enabled = false;
                    break;
                case IceSellFormState.View:
                    this.tsbNew.Enabled = true;
                    this.tsbSave.Enabled = false;
                    this.tsbDelete.Enabled = true;
                    this.tsbPrint.Enabled = true;
                    break;
            }
        }

        /// <summary>
        /// 更新合同选择
        /// </summary>
        /// <param name="customerId">客户Id</param>
        private void UpdateContractList(int customerId)
        {
            this.cmbContract.Properties.Items.Clear();
            if (customerId == 0)
            {
                this.cmbContract.EditValue = null;
                return;
            }

            var contracts = BusinessFactory<ContractBusiness>.Instance.GetByCustomer(customerId, ContractType.Ice);
            foreach (var item in contracts)
            {
                ImageComboBoxItem i = new ImageComboBoxItem();
                i.Description = item.Name;
                i.Value = item.Id;

                this.cmbContract.Properties.Items.Add(i);
            }

            if (contracts.Count > 0)
                this.cmbContract.EditValue = contracts[0].Id;
            else
                this.cmbContract.EditValue = null;
        }

        /// <summary>
        /// 初始化新建
        /// </summary>
        private void InitNew()
        {
            this.gpInfo.Visible = true;
            this.gpIce.Visible = true;

            this.dpTime.DateTime = DateTime.Now.Date;
            this.txtFlowNumber.Text = "";
            this.txtUser.Text = this.currentUser.Name;
            this.txtRemark.Text = "";
            this.irList.DataSource = new List<IceRecord>();

            IceRecord record1 = new IceRecord
            {
                IceType = (int)IceType.Complete
            };
            IceRecord record2 = new IceRecord
            {
                IceType = (int)IceType.Fragment
            };

            this.irList.AddNew(record1);
            this.irList.AddNew(record2);

            this.dpTime.Properties.ReadOnly = false;
            this.txtRemark.Properties.ReadOnly = false;
            this.lkuCustomer.ReadOnly = false;
            this.cmbContract.ReadOnly = false;
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
            var iceSales = BusinessFactory<IceSaleBusiness>.Instance.GetByFlow(this.currentFlowId);

            this.gpInfo.Visible = true;
            this.gpIce.Visible = true;

            this.dpTime.DateTime = iceFlow.FlowTime;
            this.txtFlowNumber.Text = iceFlow.FlowNumber;
            this.txtUser.Text = iceFlow.User.Name;
            this.txtRemark.Text = iceFlow.Remark;
            this.lkuCustomer.EditValue = iceFlow.Contract.CustomerId;
            this.cmbContract.EditValue = iceFlow.ContractId;

            List<IceRecord> records = new List<IceRecord>();
            foreach (var item in iceSales)
            {
                IceRecord record = new IceRecord
                {
                    IceType = item.IceType,
                    FlowCount = item.SaleCount,
                    FlowWeight = item.SaleWeight,
                    SaleUnitPrice = item.SaleUnitPrice,
                    SaleFee = item.SaleFee,
                    Remark = item.Remark
                };

                records.Add(record);
            }

            this.irList.DataSource = records;

            this.dpTime.Properties.ReadOnly = true;
            this.txtRemark.Properties.ReadOnly = true;
            this.lkuCustomer.ReadOnly = true;
            this.cmbContract.ReadOnly = true;
            this.irList.SetEditable(false);
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IceSellForm_Load(object sender, EventArgs e)
        {
            this.bsCustomer.DataSource = BusinessFactory<CustomerBusiness>.Instance.FindAll();
            this.lkuCustomer.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(EventUtil.LkuCustomer_CustomDisplayText);

            this.currentFlowId = Guid.Empty;
            this.formState = IceSellFormState.Empty;

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
            var data = BusinessFactory<IceFlowBusiness>.Instance.GetSaleByMonth(e.Node.Name);
            e.Node.Nodes.Clear();
            foreach (var item in data)
            {
                TreeNode node = new TreeNode();
                node.Name = item.Id.ToString();
                node.Text = item.FlowNumber;
                node.Tag = item.FlowType;
                node.ImageIndex = 1;
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
            this.formState = IceSellFormState.View;

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
            this.formState = IceSellFormState.Add;
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
            if (this.lkuCustomer.EditValue == null)
            {
                MessageUtil.ShowClaim("请选择客户");
                return;
            }
            if (this.cmbContract.EditValue == null)
            {
                MessageUtil.ShowClaim("请选择合同");
                return;
            }

            this.irList.CloseEditor();

            if (irList.DataSource.Any(r => r.FlowCount < 0))
            {
                MessageUtil.ShowClaim("销售数量必须大于0");
                return;
            }

            IceFlow iceFlow = new IceFlow();
            iceFlow.FlowType = (int)IceFlowType.IceSale;
            iceFlow.FlowTime = this.dpTime.DateTime.Date;
            iceFlow.ContractId = (int)this.cmbContract.EditValue;
            iceFlow.UserId = this.currentUser.Id;
            iceFlow.CreateTime = DateTime.Now;
            iceFlow.Remark = this.txtRemark.Text;

            List<IceSale> sales = new List<IceSale>();
            foreach (var item in this.irList.DataSource)
            {
                if (item.FlowCount <= 0)
                    continue;

                IceSale sale = new IceSale();
                sale.IceType = item.IceType;
                sale.SaleCount = item.FlowCount;
                sale.SaleWeight = item.FlowWeight;
                sale.SaleUnitPrice = item.SaleUnitPrice;
                sale.SaleFee = item.SaleFee;
                sale.Remark = item.Remark;

                sales.Add(sale);
            }

            if (sales.Count == 0)
            {
                MessageUtil.ShowClaim("销售数量不能全为0");
                return;
            }

            var result = BusinessFactory<IceSaleBusiness>.Instance.Create(sales, iceFlow);
            if (result == ErrorCode.Success)
            {
                MessageUtil.ShowInfo("添加冰块销售成功");

                this.currentFlowId = iceFlow.Id;
                this.formState = IceSellFormState.View;
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
                    this.formState = IceSellFormState.Empty;

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

        private void tsbPrint_Click(object sender, EventArgs e)
        {

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
        #endregion //Event

        /// <summary>
        /// 冰块界面模式
        /// </summary>
        internal enum IceSellFormState
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
