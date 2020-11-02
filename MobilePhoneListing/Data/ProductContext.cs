using MobilePhoneListing.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MobilePhoneListing.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext() : base("DefaultConnection")
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<decimal>().Configure(config => config.HasPrecision(18, 2));
        }
    }
}