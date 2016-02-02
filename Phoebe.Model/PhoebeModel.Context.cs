﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PhoebeContext : DbContext
    {
        public PhoebeContext()
            : base("name=PhoebeContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<FirstCategory> FirstCategories { get; set; }
        public virtual DbSet<SecondCategory> SecondCategories { get; set; }
        public virtual DbSet<ThirdCategory> ThirdCategories { get; set; }
        public virtual DbSet<Billing> Billings { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<StockInDetail> StockInDetails { get; set; }
        public virtual DbSet<Cargo> Cargoes { get; set; }
        public virtual DbSet<StockOut> StockOuts { get; set; }
        public virtual DbSet<StockOutDetail> StockOutDetails { get; set; }
        public virtual DbSet<StockMove> StockMoves { get; set; }
        public virtual DbSet<StockMoveDetail> StockMoveDetails { get; set; }
        public virtual DbSet<StockIn> StockIns { get; set; }
        public virtual DbSet<Settlement> Settlements { get; set; }
        public virtual DbSet<SettlementDetail> SettlementDetails { get; set; }
    }
}
