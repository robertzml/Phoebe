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
    /// 库存记录窗体
    /// </summary>
    public partial class StoreForm : BaseForm
    {
        #region Constructor
        public StoreForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Event
        private void StoreForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var data = BusinessFactory<StoreBusiness>.Instance.FindAll();
            this.bsStore.DataSource = data;
        }

        /// <summary>
        /// 自定义数据显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvStore_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            int rowIndex = e.ListSourceRowIndex;
            if (rowIndex < 0 || rowIndex >= this.bsStore.Count)
                return;

            var store = this.bsStore[rowIndex] as Store;

            if (e.Column.FieldName == "Source")
            {
                if (store.Source == 0)
                    e.DisplayText = "入库";
                else
                    e.DisplayText = "移库";
            }
            else if (e.Column.FieldName == "Destination")
            {
                if (store.Destination != null)
                {
                    if (store.Destination.Value == 0)
                        e.DisplayText = "出库";
                    else
                        e.DisplayText = "移库";
                }
            }
            else if (e.Column.FieldName == "UserId")
            {
                e.DisplayText = store.User.Name;
            }
            else if (e.Column.FieldName == "Status")
            {
                var status = (EntityStatus)e.Value;
                e.DisplayText = status.DisplayName();
            }
        }
        #endregion //Event
    }
}
