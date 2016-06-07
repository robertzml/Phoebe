using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phoebe.FormClient
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using Phoebe.Base;
    using Phoebe.Business;
    using Phoebe.Common;
    using Phoebe.Model;

    /// <summary>
    /// 通用事件处理类
    /// </summary>
    public static class EventUtil
    {
        /// <summary>
        /// 格式化客户列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void LkuCustomer_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            var lku = sender as LookUpEdit;
            if (lku.EditValue == null)
                return;

            string number = lku.GetColumnValue("Number").ToString();
            string name = lku.GetColumnValue("Name").ToString();

            e.DisplayText = string.Format("{0} - {1}", number, name);
        }
    }
}
