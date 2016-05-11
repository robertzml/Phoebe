using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phoebe.FormClient
{
    public partial class GridNavigator : UserControl
    {
        #region Field
        /// <summary>
        /// 关联表格
        /// </summary>
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        #endregion //Field

        #region Constructor
        public GridNavigator()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        private bool TestGridView()
        {
            if (this.gridView == null)
                return false;
            else
                return true;
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 添加行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddRow_Click(object sender, EventArgs e)
        {
            this.gridView.AddNewRow();
            this.gridView.UpdateCurrentRow();
        }

        /// <summary>
        /// 删除行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            this.gridView.HideEditor();
            this.gridView.DeleteRow(this.gridView.FocusedRowHandle);
        }
        #endregion //Event


        #region Property
        /// <summary>
        /// 关联表格
        /// </summary>
        public DevExpress.XtraGrid.Views.Grid.GridView GridView
        {
            get
            {
                return this.gridView;
            }
            set
            {
                this.gridView = value;
            }
        }
        #endregion //Property
    }
}
