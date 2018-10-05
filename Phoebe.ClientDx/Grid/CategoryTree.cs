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
    /// 类别树形控件
    /// </summary>
    public partial class CategoryTree : DevExpress.XtraEditors.XtraUserControl
    {
        #region Constructor
        public CategoryTree()
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
            var data = BusinessFactory<CategoryBusiness>.Instance.FindAll();
            this.bsCategory.DataSource = data;
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        public void RefreshData()
        {
            var data = BusinessFactory<CategoryBusiness>.Instance.FindAll();
            this.bsCategory.DataSource = data;
        }

        /// <summary>
        /// 获取当前选中类别
        /// </summary>
        /// <returns></returns>
        public Category GetCurrentSelect()
        {
            var node = this.treeCategory.Selection[0];

            if (node == null)
                return null;

            var data = this.bsCategory[node.Id] as Category;
            return data;
        }
        #endregion //Method

        #region Delegate
        /// <summary>
        /// 类别选择事件
        /// </summary>
        [Description("类别选择事件")]
        public event Action<object, EventArgs> CategorySelected;
        #endregion //Delegate

        #region Event
        /// <summary>
        /// 树形列表选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeCategory_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            CategorySelected?.Invoke(sender, e);
        }
        #endregion //Event
    }
}
