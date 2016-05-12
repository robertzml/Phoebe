using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phoebe.FormClient
{
    /// <summary>
    /// 货品入库查看
    /// </summary>
    public partial class StockInViewControl : UserControl
    {
        #region Field
        /// <summary>
        /// 关联入库单ID
        /// </summary>
        private Guid stockInId;
        #endregion //Field

        #region Constructor
        public StockInViewControl(Guid stockInId)
        {
            InitializeComponent();
            this.stockInId = stockInId;
        }
        #endregion //Constructor

        #region Event
        private void StockInViewControl_Load(object sender, EventArgs e)
        {

        }
        #endregion //Event
    }
}
