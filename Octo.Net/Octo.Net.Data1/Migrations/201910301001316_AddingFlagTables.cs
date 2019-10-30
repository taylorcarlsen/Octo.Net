namespace Octo.Net.Data1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingFlagTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblArtworkFlags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArtworkId = c.Int(nullable: false),
                        FlagId = c.Int(nullable: false),
                        Comment = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblFlagOptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblFlagOptions");
            DropTable("dbo.tblArtworkFlags");
        }
    }
}
