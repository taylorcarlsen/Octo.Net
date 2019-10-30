namespace Octo.Net.Data1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Revert : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.tblArtworkFlags");
            DropTable("dbo.tblFlagOptions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tblFlagOptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblArtworkFlags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArtworkId = c.Int(nullable: false),
                        FlagId = c.Int(nullable: false),
                        Comment = c.String(maxLength: 25),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
