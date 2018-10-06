using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phoebe.ClientDx
{
    using Poseidon.Base.Framework;
    using Poseidon.Winform.Base;
    using Phoebe.Base;
    using Phoebe.Core.BL;
    using Phoebe.Core.DL;

    /// <summary>
    /// 合同列表窗体
    /// </summary>
    public partial class FrmContractList : BaseMdiForm
    {
        #region Constructor
        public FrmContractList()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        protected override void InitForm()
        {
            this.contractGrid.Init();

            LoadData();
            base.InitForm();
        }

        /// <summary>
        /// 载入数据
        /// </summary>
        private void LoadData()
        {
            var data = BusinessFactory<ContractBusiness>.Instance.FindAll().ToList();
            this.contractGrid.DataSource = data;
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 添加合同
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ChildFormManage.ShowDialogForm(typeof(FrmContractAdd));
            LoadData();
        }
        #endregion //Event
    }
}
