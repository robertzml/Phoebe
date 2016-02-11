using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phoebe.Business;
using Phoebe.Common;
using Phoebe.Model;

namespace Phoebe.FormUI
{
    /// <summary>
    /// 合同列表窗体
    /// </summary>
    public partial class ContractForm : Form
    {
        #region Field
        private ContractBusiness contractBusiness;

        private List<Contract> contractData;
        #endregion//Field

        #region Constructor
        public ContractForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        private void InitData()
        {
            this.contractBusiness = new ContractBusiness();
            this.contractData = this.contractBusiness.Get();
        }

        private void InitControl()
        {
            this.contractBindingSource.DataSource = this.contractData;
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContractForm_Load(object sender, EventArgs e)
        {
            InitData();
            InitControl();
        }

        private void contractDataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < this.contractBindingSource.Count)
            {
                var contract = this.contractBindingSource[e.RowIndex] as Contract;

                var grid = this.contractDataGridView;
                if (contract.Customer != null)
                {
                    grid.Rows[e.RowIndex].Cells[this.columnCustomerName.Index].Value = contract.Customer.Name;
                }
                grid.Rows[e.RowIndex].Cells[this.columnBillingType.Index].Value = ((BillingType)contract.BillingType).DisplayName();
                grid.Rows[e.RowIndex].Cells[this.columnBillingInfo.Index].Value = ((BillingType)contract.BillingType).DisplayDescription();

                if (contract.User != null)
                {
                    grid.Rows[e.RowIndex].Cells[this.columnUser.Index].Value = contract.User.Name;
                }
            }
        }
        #endregion //Event
    }
}
