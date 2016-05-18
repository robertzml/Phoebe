using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    /// 货品移库窗体
    /// </summary>
    public partial class StockMoveForm : BaseForm
    {
        #region Field
        /// <summary>
        /// 当前移库单ID
        /// </summary>
        private Guid currentStockMoveId;

        /// <summary>
        /// 当前移库单状态
        /// </summary>
        private EntityStatus stockMoveState;

        /// <summary>
        /// 界面流程状态
        /// </summary>
        private StockMoveFormState formState;

        /// <summary>
        /// 新建移库界面
        /// </summary>
        private StockMoveAddControl stockMoveAdd;
        #endregion //Field

        #region Constructor
        public StockMoveForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 更新工具栏状态
        /// </summary>
        private void UpdateToolbar()
        {
            switch (this.stockMoveState)
            {
                case EntityStatus.Empty:
                    this.tsbNew.Enabled = true;
                    this.tsbSave.Enabled = false;
                    this.tsbConfirm.Enabled = false;
                    this.tsbPrint.Enabled = false;
                    this.tsbEdit.Enabled = false;
                    this.tsbRevert.Enabled = false;
                    this.tsbDelete.Enabled = false;
                    if (this.formState == StockMoveFormState.Add)
                    {
                        this.tsbSave.Enabled = true;
                    }
                    break;
                case EntityStatus.StockMoveReady:
                    if (this.formState == StockMoveFormState.View)
                    {
                        this.tsbNew.Enabled = true;
                        this.tsbSave.Enabled = false;
                        this.tsbConfirm.Enabled = true;
                        this.tsbPrint.Enabled = true;
                        this.tsbEdit.Enabled = true;
                        this.tsbRevert.Enabled = false;
                        this.tsbDelete.Enabled = true;
                    }
                    else if (this.formState == StockMoveFormState.Edit)
                    {
                        this.tsbNew.Enabled = true;
                        this.tsbSave.Enabled = true;
                        this.tsbConfirm.Enabled = false;
                        this.tsbPrint.Enabled = false;
                        this.tsbEdit.Enabled = false;
                        this.tsbRevert.Enabled = false;
                        this.tsbDelete.Enabled = false;
                    }
                    break;
                case EntityStatus.StockMove:
                    this.tsbNew.Enabled = true;
                    this.tsbSave.Enabled = false;
                    this.tsbConfirm.Enabled = false;
                    this.tsbPrint.Enabled = true;
                    this.tsbEdit.Enabled = false;
                    this.tsbRevert.Enabled = true;
                    this.tsbDelete.Enabled = false;
                    break;
            }
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StockMoveForm_Load(object sender, EventArgs e)
        {
            this.currentStockMoveId = Guid.Empty;
            this.stockMoveState = EntityStatus.Empty;
            this.formState = StockMoveFormState.Empty;

            //UpdateTree();
            UpdateToolbar();
        }

        /// <summary>
        /// 新建移库单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbNew_Click(object sender, EventArgs e)
        {
            this.currentStockMoveId = Guid.Empty;
            this.stockMoveState = EntityStatus.Empty;
            this.formState = StockMoveFormState.Add;

            UpdateToolbar();

            this.stockMoveAdd = new StockMoveAddControl(this.currentUser);
            ChildFormManage.LoadContentControl(this.plBody, this.stockMoveAdd);
        }
        #endregion //Event

        /// <summary>
        /// 移库界面模式
        /// </summary>
        internal enum StockMoveFormState
        {
            /// <summary>
            /// 空
            /// </summary>
            Empty = 0,

            /// <summary>
            /// 新增模式
            /// </summary>
            Add = 1,

            /// <summary>
            /// 查看模式
            /// </summary>
            View = 2,

            /// <summary>
            /// 编辑模式
            /// </summary>
            Edit = 3
        }
    }
}
