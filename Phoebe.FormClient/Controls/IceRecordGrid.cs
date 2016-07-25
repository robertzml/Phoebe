using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Phoebe.FormClient
{
    using Phoebe.Common;
    using Phoebe.Model;

    /// <summary>
    /// 冰块记录控件
    /// </summary>
    public partial class IceRecordGrid : UserControl
    {
        #region Field
        /// <summary>
        /// 是否能编辑
        /// </summary>
        private bool editable = true;

        /// <summary>
        /// 是否销售
        /// </summary>
        private bool isSale = false;
        #endregion //Field

        #region Constructor
        public IceRecordGrid()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 清空数据
        /// </summary>
        public void Clear()
        {
            this.bsIceRecord.Clear();
        }

        /// <summary>
        /// 获取选中数据
        /// </summary>
        /// <returns></returns>
        public IceRecord GetCurrentSelect()
        {
            int rowIndex = this.dgvIce.GetFocusedDataSourceRowIndex();
            if (rowIndex < 0 || rowIndex >= this.bsIceRecord.Count)
                return null;
            else
                return this.bsIceRecord[rowIndex] as IceRecord;
        }

        /// <summary>
        /// 新增行
        /// </summary>
        /// <param name="record">冰块记录</param>
        public void AddNew(IceRecord record)
        {
            this.bsIceRecord.Add(record);
            this.bsIceRecord.ResetBindings(false);
        }

        /// <summary>
        /// 更新列表绑定数据显示
        /// </summary>
        public void UpdateBindingData()
        {
            this.bsIceRecord.ResetBindings(false);
        }

        /// <summary>
        /// 完成编辑
        /// </summary>
        public void CloseEditor()
        {
            this.dgvIce.CloseEditor();
        }

        /// <summary>
        /// 设置是否能编辑
        /// </summary>
        /// <param name="editable">能否编辑</param>
        public void SetEditable(bool editable)
        {
            this.dgvIce.OptionsBehavior.Editable = editable;
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// 控件载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IceRecordGrid_Load(object sender, EventArgs e)
        {
            this.colSaleUnitPrice.Visible = this.isSale;
            this.colSaleFee.Visible = this.isSale;
            this.colRemark.Visible = this.isSale;
        }

        /// <summary>
        /// 格式化数据显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvIce_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            int rowIndex = e.ListSourceRowIndex;
            if (rowIndex < 0 || rowIndex >= this.bsIceRecord.Count)
                return;

            var iceRecord = this.bsIceRecord[rowIndex] as IceRecord;
            if (e.Column.FieldName == "IceType")
            {
                e.DisplayText = ((IceType)iceRecord.IceType).DisplayName();
            }
        }
        #endregion //Event

        #region Property
        /// <summary>
        /// 数据源
        /// </summary>
        [Description("数据源")]
        public List<IceRecord> DataSource
        {
            get
            {
                return this.bsIceRecord.DataSource as List<IceRecord>;
            }
            set
            {
                this.dgvIce.BeginDataUpdate();
                this.bsIceRecord.DataSource = value;
                this.dgvIce.EndDataUpdate();
            }
        }

        /// <summary>
        /// 是否能编辑
        /// </summary>
        [Description("是否能编辑")]
        public bool Editable
        {
            get
            {
                return this.editable;
            }
            set
            {
                this.editable = value;
            }
        }

        /// <summary>
        /// 是否销售
        /// </summary>
        [Description("是否销售")]
        public bool IsSale
        {
            get
            {
                return this.isSale;
            }
            set
            {
                this.isSale = value;
            }
        }
        #endregion //Property
    }
}
