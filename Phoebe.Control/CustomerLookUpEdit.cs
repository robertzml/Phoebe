using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Phoebe.Control
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using Phoebe.Model;

    public class CustomerLookUpEdit: LookUpEdit
    {
        private BindingSource bsCustomer;

        public CustomerLookUpEdit()
        {
            this.bsCustomer = new BindingSource();

            this.bsCustomer.DataSource = typeof(Customer);

            this.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Number", "代码", 53, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "名称", 41, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.Properties.DataSource = this.bsCustomer;
            this.Properties.DisplayMember = "Number";
            this.Properties.DropDownRows = 10;
            this.Properties.ImmediatePopup = true;
            this.Properties.NullText = "请选择客户";
            this.Properties.ShowFooter = false;
            this.Properties.ValueMember = "Id";

            this.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.LookUp_CustomDisplayText);
        }

        private void LookUp_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            if (this.EditValue == null)
                return;

            string Column1 = GetColumnValue("Number").ToString();
            string Column2 = GetColumnValue("Name").ToString();

            e.DisplayText = String.Format("{0} - {1}",
                Column1,
                Column2);
        }
    }
}
