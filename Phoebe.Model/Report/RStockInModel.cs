using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Model.Report
{
    public class RStockInModel
    {

        public string CustomerName { get; set; }

        public string UserName { get; set; }

        public List<RStockInDetailsModel> Details { get; set; }
    }
}
