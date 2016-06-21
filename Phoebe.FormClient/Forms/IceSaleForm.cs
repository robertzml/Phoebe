using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Phoebe.FormClient
{
    using Phoebe.Base;
    using Phoebe.Business;
    using Phoebe.Common;
    using Phoebe.Model;

    /// <summary>
    /// 冰块销售窗体
    /// </summary>
    public partial class IceSaleForm : BaseForm
    {
        public IceSaleForm()
        {
            InitializeComponent();
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            ChildFormManage.ShowDialogForm(typeof(IceSellForm));
        }
    }
}
