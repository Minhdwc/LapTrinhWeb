using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace project_1.Models
{
    public class DBContext : DbContext
    {
        public DBContext() : base("MyConnectString") { }
        public DbSet<Brands> Brands { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
    }
} 