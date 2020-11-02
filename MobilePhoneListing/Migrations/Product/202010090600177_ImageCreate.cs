namespace MobilePhoneListing.Migrations.Product
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageCreate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ImagePath", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "ImagePath", c => c.String());
        }
    }
}
