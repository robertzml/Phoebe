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
    public partial class CategoryForm : Form
    {
        #region Field

        #endregion //Field

        #region Constructor
        public CategoryForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Event
        private void CategoryForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 添加一级分类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddFirst_Click(object sender, EventArgs e)
        {
            CategoryFirstAddForm form = new CategoryFirstAddForm();
            form.ShowDialog();
        }
        #endregion //Event
    }
}
