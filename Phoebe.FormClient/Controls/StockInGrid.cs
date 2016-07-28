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
    using Phoebe.Model;

    /// <summary>
    /// 入库货品表格控件
    /// </summary>
    public partial class StockInGrid : UserControl
    {
        #region Field
        /// <summary>
        /// 是否能编辑
        /// </summary>
        private bool editable = true;

        /// <summary>
        /// 是否等重
        /// </summary>
        private bool isEqualWeight = true;

        /// <summary>
        /// 分类列表，缓存控件使用
        /// </summary>
        private List<Category> categoryList;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 入库货品表格控件
        /// </summary>
        public StockInGrid()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 更新列表绑定数据显示
        /// </summary>
        public void UpdateBindingData()
        {
            this.bsStockIn.ResetBindings(false);
        }

        /// <summary>
        /// 设置分类信息
        /// </summary>
        /// <param name="data">分类信息</param>
        public void SetCategoryList(List<Category> data)
        {
            this.categoryList = data;
        }

        /// <summary>
        /// 新增行
        /// </summary>
        public void AddNew()
        {
            this.bsStockIn.Add(new StockInModel());
            this.bsStockIn.ResetBindings(false);
        }

        /// <summary>
        /// 删除当前行
        /// </summary>
        public void RemoveCurrent()
        {
            int rowIndex = this.dgvStockIn.GetFocusedDataSourceRowIndex();
            if (rowIndex < 0 || rowIndex >= this.bsStockIn.Count)
                return;

            this.bsStockIn.RemoveAt(rowIndex);
            this.bsStockIn.ResetBindings(false);
            return;
        }

        /// <summary>
        /// 设置货品是否等重
        /// </summary>
        /// <param name="isEqualWeight">是否等重</param>
        public void SetEqualWeight(bool isEqualWeight)
        {
            this.colInWeight.OptionsColumn.AllowEdit = !isEqualWeight;
            this.isEqualWeight = isEqualWeight;
        }

        /// <summary>
        /// 完成编辑
        /// </summary>
        public void CloseEditor()
        {
            this.dgvStockIn.CloseEditor();
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// 控件载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StockInGrid_Load(object sender, EventArgs e)
        {
            this.dgvStockIn.OptionsBehavior.Editable = this.editable;
        }

        /// <summary>
        /// 单元格更改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvStockIn_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.Name == "colCategoryNumber")
            {
                string number = e.Value.ToString();
                if (CellValueChanged != null)
                {
                    DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs arg = new DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs(e.RowHandle, e.Column, number);                    
                    CellValueChanged(sender,arg);
                }

                var category = this.categoryList.SingleOrDefault(r => r.Number == number);
                if (category != null)
                {
                    this.dgvStockIn.SetRowCellValue(e.RowHandle, "CategoryName", category.Name);
                    this.dgvStockIn.SetRowCellValue(e.RowHandle, "CategoryId", category.Id);
                }
                else
                {
                    this.dgvStockIn.SetRowCellValue(e.RowHandle, "CategoryName", "");
                    this.dgvStockIn.SetRowCellValue(e.RowHandle, "CategoryId", 0);
                }
            }
            else if (e.Column.Name == "colInCount")
            {
                int count = 0;
                if (!Int32.TryParse(e.Value.ToString(), out count))
                    return;

                if (this.isEqualWeight)
                {
                    decimal unitWeight = Convert.ToDecimal(this.dgvStockIn.GetRowCellValue(e.RowHandle, "UnitWeight"));
                    decimal totalWeight = count * unitWeight / 1000;
                    this.dgvStockIn.SetRowCellValue(e.RowHandle, "InWeight", totalWeight);
                }

                decimal unitVolume = Convert.ToDecimal(this.dgvStockIn.GetRowCellValue(e.RowHandle, "UnitVolume"));
                decimal totalVolume = count * unitVolume;
                this.dgvStockIn.SetRowCellValue(e.RowHandle, "InVolume", totalVolume);
            }
            else if (e.Column.Name == "colUnitWeight")
            {
                if (!this.isEqualWeight)
                    return;

                decimal unitWeight = 0;
                if (!decimal.TryParse(e.Value.ToString(), out unitWeight))
                    return;

                int count = Convert.ToInt32(this.dgvStockIn.GetRowCellValue(e.RowHandle, "InCount"));
                decimal totalWeight = count * unitWeight / 1000;
                this.dgvStockIn.SetRowCellValue(e.RowHandle, "InWeight", totalWeight);
            }
            else if (e.Column.Name == "colUnitVolume")
            {
                decimal unitVolume = 0;
                if (!decimal.TryParse(e.Value.ToString(), out unitVolume))
                    return;

                int count = Convert.ToInt32(this.dgvStockIn.GetRowCellValue(e.RowHandle, "InCount"));
                decimal totalVolume = count * unitVolume;
                this.dgvStockIn.SetRowCellValue(e.RowHandle, "InVolume", totalVolume);
            }
        }
        #endregion //Event

        #region Property
        /// <summary>
        /// 数据源
        /// </summary>
        [Description("数据源")]
        public List<StockInModel> DataSource
        {
            get
            {
                return this.bsStockIn.DataSource as List<StockInModel>;
            }
            set
            {
                this.bsStockIn.DataSource = value;
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
        #endregion //Property

        #region Delegate
        //定义委托
        public delegate void CellChangedHandle(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e);

        //定义事件
        [Description("单元格更改事件")]
        public event CellChangedHandle CellValueChanged;
        #endregion //Delegate
    }
}
