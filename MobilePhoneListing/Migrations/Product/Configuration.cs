namespace MobilePhoneListing.Migrations.Product
{
    using MobilePhoneListing.Data;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MobilePhoneListing.Data.ProductContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Product";
        }

        protected override void Seed(MobilePhoneListing.Data.ProductContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Products.AddOrUpdate(
               p => new { p.ProductName, p.ShortDescription, p.LongDescription, p.Specification, p.ImagePath, p.Price }, DummyData.getProducts().ToArray());
        }
    }
}
