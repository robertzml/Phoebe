using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phoebe.ClientDx
{
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Winform.Base;
    using Poseidon.Common;
    using Phoebe.Core.BL;
    using Phoebe.Core.DL;
    using Phoebe.Core.Utility;

    /// <summary>
    /// 货品列表控件
    /// </summary>
    public partial class CargoGrid : WinEntityGrid<Cargo>
    {
        #region Field
        /// <summary>
        /// 缓存合同
        /// </summary>
        private List<Contract> contractList;
        #endregion //Field

        #region Constructor
        public CargoGrid()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            this.contractList = BusinessFactory<ContractBusiness>.Instance.FindAll().ToList();
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// 格式化数据显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvEntity_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            int rowIndex = e.ListSourceRowIndex;
            if (rowIndex < 0 || rowIndex >= this.bsEntity.Count)
                return;

            if (e.Column.FieldName == "ContractId")
            {
                var cargo = this.bsEntity[rowIndex] as Cargo;

                var contract = this.contractList.Find(r => r.Id == cargo.ContractId);
                if (contract != null)
                    e.DisplayText = contract.Name;
            }
            else if (e.Column.FieldName == "GroupType")
            {
                e.DisplayText = ((BillingType)e.Value).DisplayName();
            }
        }
        #endregion //Event
    }
}
