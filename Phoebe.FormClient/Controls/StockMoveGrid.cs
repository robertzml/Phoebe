using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Phoebe.FormClient
{
    using Phoebe.Model;

    /// <summary>
    /// 移库货品表格控件
    /// </summary>
    public partial class StockMoveGrid : UserControl
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
        /// 是否显示移库数量
        /// </summary>
        private bool showMoveCount = true;

        /// <summary>
        /// 是否等重
        /// </summary>
        private bool isEqualWeight = true;
        #endregion //Field

        #region Constructor
        public StockMoveGrid()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 完成编辑
        /// </summary>
        public void CloseEditor()
        {
            this.dgvStockMove.CloseEditor();
        }

        /// <summary>
        /// 清空数据
        /// </summary>
        public void Clear()
        {
            this.bsStockMove.Clear();
        }

        /// <summary>
        /// 获取选中数据
        /// </summary>
        /// <returns></returns>
        public StockMoveModel GetCurrentSelect()
        {
            int rowIndex = this.dgvStockMove.GetFocusedDataSourceRowIndex();
            if (rowIndex < 0 || rowIndex >= this.bsStockMove.Count)
                return null;
            else
                return this.bsStockMove[rowIndex] as StockMoveModel;
        }

        /// <summary>
        /// 更新列表绑定数据显示
        /// </summary>
        public void UpdateBindingData()
        {
            this.bsStockMove.ResetBindings(false);
        }

        /// <summary>
        /// 设置货品是否等重
        /// </summary>
        /// <param name="isEqualWeight">是否等重</param>
        public void SetEqualWeight(bool isEqualWeight)
        {
            this.colMoveWeight.OptionsColumn.AllowEdit = !isEqualWeight;
            this.isEqualWeight = isEqualWeight;
        }

        /// <summary>
        /// 判断当前是否已有相应库存
        /// </summary>
        /// <param name="model">检查对象</param>
        /// <returns></returns>
        public bool CheckHasStore(StockMoveModel model)
        {
            var data = this.bsStockMove.DataSource as List<StockMoveModel>;
            if (data.Any(r => r.SourceStoreId == model.SourceStoreId))
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
        private void StockMoveGrid_Load(object sender, EventArgs e)
        {
            this.dgvStockMove.OptionsBehavior.Editable = this.editable;
            this.dgvStockMove.OptionsView.ShowFooter = this.showFooter;
            this.colMoveCount.Visible = this.showMoveCount;
            this.colMoveWeight.Visible = this.showMoveCount;
            this.colMoveVolume.Visible = this.showMoveCount;
            this.colRemark.Visible = this.showMoveCount;
        }

        /// <summary>
        /// 单元格更改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvStockMove_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.Name == "colMoveCount")
            {
                int count = 0;
                if (!Int32.TryParse(e.Value.ToString(), out count))
                {
                    return;
                }

                if (this.isEqualWeight)
                {
                    double unitWeight = Convert.ToDouble(this.dgvStockMove.GetRowCellValue(e.RowHandle, "UnitWeight"));
                    double totalWeight = count * unitWeight / 1000;
                    this.dgvStockMove.SetRowCellValue(e.RowHandle, "MoveWeight", totalWeight);
                }

                double unitVolume = Convert.ToDouble(this.dgvStockMove.GetRowCellValue(e.RowHandle, "UnitVolume"));
                double totalVolume = count * unitVolume;
                this.dgvStockMove.SetRowCellValue(e.RowHandle, "MoveVolume", totalVolume);
            }
        }
        #endregion //Event

        #region Property
        /// <summary>
        /// 数据源
        /// </summary>
        [Description("数据源")]
        public List<StockMoveModel> DataSource
        {
            get
            {
                return this.bsStockMove.DataSource as List<StockMoveModel>;
            }
            set
            {
                this.bsStockMove.DataSource = value;
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
        /// 是否显示移库数量，移库重量，移库体积
        /// </summary>
        [Description("是否显示移库数量，移库重量，移库体积")]
        public bool ShowMoveCount
        {
            get
            {
                return this.showMoveCount;
            }
            set
            {
                this.showMoveCount = value;
            }
        }
        #endregion //Property
    }
}
