using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Phoebe.FormClient
{
    using Phoebe.Model;

    /// <summary>
    /// 出库货品表格控件
    /// </summary>
    public partial class StockOutGrid : UserControl
    {
        #region Field
        /// <summary>
        /// 是否能编辑
        /// </summary>
        private bool editable = true;

        /// <summary>
        /// 是否显示Footer
        /// </summary>
        private bool showFooter = true;

        /// <summary>
        /// 是否显示出库数量
        /// </summary>
        private bool showOutCount = true;

        /// <summary>
        /// 是否等重
        /// </summary>
        private bool isEqualWeight = true;
        #endregion //Field

        #region Constructor
        public StockOutGrid()
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
            this.bsStockOut.Clear();
        }

        /// <summary>
        /// 获取选中数据
        /// </summary>
        /// <returns></returns>
        public StockOutModel GetCurrentSelect()
        {
            int rowIndex = this.dgvStockOut.GetFocusedDataSourceRowIndex();
            if (rowIndex < 0 || rowIndex >= this.bsStockOut.Count)
                return null;
            else
                return this.bsStockOut[rowIndex] as StockOutModel;
        }

        /// <summary>
        /// 更新列表绑定数据显示
        /// </summary>
        public void UpdateBindingData()
        {
            this.bsStockOut.ResetBindings(false);
        }

        /// <summary>
        /// 设置货品是否等重
        /// </summary>
        /// <param name="isEqualWeight">是否等重</param>
        public void SetEqualWeight(bool isEqualWeight)
        {
            this.colOutWeight.OptionsColumn.AllowEdit = !isEqualWeight;
            this.isEqualWeight = isEqualWeight;
        }

        /// <summary>
        /// 完成编辑
        /// </summary>
        public void CloseEditor()
        {
            this.dgvStockOut.CloseEditor();
        }

        /// <summary>
        /// 判断当前是否已有相应库存
        /// </summary>
        /// <param name="model">检查对象</param>
        /// <returns></returns>
        public bool CheckHasStore(StockOutModel model)
        {
            var data = this.bsStockOut.DataSource as List<StockOutModel>;
            if (data.Any(r => r.StoreId == model.StoreId))
                return true;
            else
                return false;
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// 控件载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StockOutGrid_Load(object sender, EventArgs e)
        {
            this.dgvStockOut.OptionsBehavior.Editable = this.editable;
            this.dgvStockOut.OptionsView.ShowFooter = this.showFooter;
            this.colOutCount.Visible = this.showOutCount;
            this.colOutWeight.Visible = this.showOutCount;
            this.colOutVolume.Visible = this.showOutCount;
            this.colRemark.Visible = this.showOutCount;
        }

        /// <summary>
        /// 单元格更改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvStockOut_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.Name == "colOutCount")
            {
                int count = 0;
                if (!Int32.TryParse(e.Value.ToString(), out count))
                {
                    return;
                }

                if (this.isEqualWeight)
                {
                    decimal unitWeight = Convert.ToDecimal(this.dgvStockOut.GetRowCellValue(e.RowHandle, "UnitWeight"));
                    decimal totalWeight = count * unitWeight / 1000;
                    this.dgvStockOut.SetRowCellValue(e.RowHandle, "OutWeight", totalWeight);
                }

                decimal unitVolume = Convert.ToDecimal(this.dgvStockOut.GetRowCellValue(e.RowHandle, "UnitVolume"));
                decimal totalVolume = count * unitVolume;
                this.dgvStockOut.SetRowCellValue(e.RowHandle, "OutVolume", totalVolume);
            }
        }
        #endregion //Event

        #region Property
        /// <summary>
        /// 数据源
        /// </summary>
        [Description("数据源")]
        public List<StockOutModel> DataSource
        {
            get
            {
                return this.bsStockOut.DataSource as List<StockOutModel>;
            }
            set
            {
                this.bsStockOut.DataSource = value;
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
        /// 是否显示Footer
        /// </summary>
        [Description("是否显示Footer")]
        public bool ShowFooter
        {
            get
            {
                return this.showFooter;
            }
            set
            {
                this.showFooter = value;
            }
        }

        /// <summary>
        /// 是否显示出库数量，出库重量，出库体积
        /// </summary>
        [Description("是否显示出库数量，出库重量，出库体积")]
        public bool ShowOutCount
        {
            get
            {
                return this.showOutCount;
            }
            set
            {
                this.showOutCount = value;
            }
        }
        #endregion //Property
    }
}
