namespace Octo.Net.Data1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateCreated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblArtworks", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.tblGalleries", "DateCreated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblGalleries", "DateCreated");
            DropColumn("dbo.tblArtworks", "DateCreated");
        }
    }
}
