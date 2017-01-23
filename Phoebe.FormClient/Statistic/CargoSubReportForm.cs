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
    /// 货品分项报表窗体
    /// </summary>
    public partial class CargoSubReportForm : BaseForm
    {
        #region Field
        /// <summary>
        /// 选中类别
        /// </summary>
        private Category selectCategory = null;
        #endregion //Field

        #region Constructor
        public CargoSubReportForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        private void LoadTree()
        {
            var category = BusinessFactory<CategoryBusiness>.Instance.GetAll();

            this.bsCategory.DataSource = category;
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CargoSubReportForm_Load(object sender, EventArgs e)
        {
            LoadTree();

            this.dpDate.DateTime = DateTime.Now.Date;
        }

        /// <summary>
        /// 选中类别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tlCategory_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            var id = e.Node.GetValue("Id");

            this.selectCategory = BusinessFactory<CategoryBusiness>.Instance.FindById(id);

            this.txtCategoryNumber.Text = selectCategory.Number;
            this.txtCategoryName.Text = selectCategory.Name;

            if (this.selectCategory.Hierarchy == 1)
                this.btnSearch.Enabled = false;
            else
                this.btnSearch.Enabled = true;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.selectCategory == null)
                return;

            if (this.selectCategory.Hierarchy <= 1)
                return;

            var date = this.dpDate.DateTime.Date;

            this.Cursor = Cursors.WaitCursor;

            var data = BusinessFactory<StatisticBusiness>.Instance.GetCargoSub(this.selectCategory.Id, date, this.chkChildren.Checked);

            this.csList.DataSource = data;
            this.csList.StorageDate = date;

            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.csList.PrintPriview();
        }
        #endregion //Event
    }
}
