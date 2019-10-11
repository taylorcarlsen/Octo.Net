namespace Octo.Net.Data1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblArtworks", "ArtworkImagePath", c => c.String());
            AddColumn("dbo.tblUsers", "UserProfileImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblUsers", "UserProfileImagePath");
            DropColumn("dbo.tblArtworks", "ArtworkImagePath");
        }
    }
}
