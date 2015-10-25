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
    
    public partial class Contract
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Contract()
        {
            this.Cargoes = new HashSet<Cargo>();
            this.ColdSettlements = new HashSet<ColdSettlement>();
        }
    
        public int ID { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public int CustomerType { get; set; }
        public int CustomerID { get; set; }
        public System.DateTime SignDate { get; set; }
        public Nullable<System.DateTime> CloseDate { get; set; }
        public int BillingType { get; set; }
        public bool IsTiming { get; set; }
        public string CertificateNumber { get; set; }
        public int UserID { get; set; }
        public string Remark { get; set; }
        public int Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cargo> Cargoes { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ColdSettlement> ColdSettlements { get; set; }
    }
}
