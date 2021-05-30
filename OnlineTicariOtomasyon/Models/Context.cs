using OnlineTicariOtomasyon.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models
{
    public class Context : DbContext
    {
        public DbSet<Cari> Caris { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Expenses> Expenses { get; set; }

        public DbSet<Login> Logins { get; set; }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<CargoTracking> CargoTrackings { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoicesItem> InvoicesItems { get; set; }



    }
}