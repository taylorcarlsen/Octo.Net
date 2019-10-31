namespace Octo.Net.Data1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingUserIdToArtworkFlag : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblArtworkFlags", "UserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblArtworkFlags", "UserId");
        }
    }
}
