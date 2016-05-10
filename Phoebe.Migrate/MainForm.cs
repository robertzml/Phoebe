using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phoebe.Migrate
{
    public partial class MainForm : Form
    {
        #region Field
        SqlHelper sqlHelper = new SqlHelper();
        #endregion //Field

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            string readSql = "SELECT * FROM Customer";
            DataTable dt = sqlHelper.Read(readSql);

            List<string> bulk = new List<string>();
            bulk.Add("SET IDENTITY_INSERT Customer ON;");
            foreach (DataRow row in dt.Rows)
            {
                string sql = string.Format("INSERT INTO Customer (Id, Name, Number, Address, Telephone, Type, Remark, Status) " +
                    "VALUES({0}, '{1}', '{2}', '{3}', '{4}', {5}, '{6}', {7})", row["ID"], row["Name"], row["Number"] == null ? "" : row["Number"],
                    row["Address"], row["Telephone"], row["Type"], row["Remark"], row["Status"]);

                bulk.Add(sql);
            }
            bulk.Add("SET IDENTITY_INSERT Customer OFF;");

            string result = sqlHelper.Insert(bulk);

            this.txtMessage.AppendText(result + "\r\n");
        }


        private void btnContract_Click(object sender, EventArgs e)
        {
            string readSql = "SELECT * FROM Contract";
            DataTable dt = sqlHelper.Read(readSql);

            List<string> bulk = new List<string>();
            bulk.Add("SET IDENTITY_INSERT Contract ON;");
            foreach (DataRow row in dt.Rows)
            {
                string sql = string.Format("INSERT INTO Contract (Id, Number, Name, CustomerId, SignDate, BillingType, IsTiming, UserId, Remark, Status) " +
                    "VALUES({0}, '{1}', '{2}', {3}, '{4}', {5}, {6}, {7}, '{8}', {9})",
                    row["ID"], row["Number"], row["Name"], row["CustomerId"], row["SignDate"], row["BillingType"],
                    Convert.ToInt32(row["IsTiming"]), 2, row["Remark"], 0);

                bulk.Add(sql);
            }
            bulk.Add("SET IDENTITY_INSERT Contract OFF;");

            string result = sqlHelper.Insert(bulk);

            this.txtMessage.AppendText(result + "\r\n");
        }



        private void btnDelCustomer_Click(object sender, EventArgs e)
        {
            string delSql = "DELETE FROM Customer";
            string result = sqlHelper.Delete(delSql);

            this.txtMessage.AppendText(result + "\r\n");
        }

        private void btnDelContract_Click(object sender, EventArgs e)
        {
            string delSql = "DELETE FROM Contract";
            string result = sqlHelper.Delete(delSql);

            this.txtMessage.AppendText(result + "\r\n");
        }

    }
}
