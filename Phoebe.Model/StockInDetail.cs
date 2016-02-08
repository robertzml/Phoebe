//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Phoebe.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class StockInDetail
    {
        public System.Guid ID { get; set; }
        public System.Guid StockInID { get; set; }
        public int WarehouseID { get; set; }
        public System.Guid CargoID { get; set; }
        public int Count { get; set; }
        public double InWeight { get; set; }
        public Nullable<System.Guid> StockID { get; set; }
        public string Remark { get; set; }
        public int Status { get; set; }
    
        public virtual StockIn StockIn { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        public virtual Stock Stock { get; set; }
        public virtual Cargo Cargo { get; set; }
    }
}
