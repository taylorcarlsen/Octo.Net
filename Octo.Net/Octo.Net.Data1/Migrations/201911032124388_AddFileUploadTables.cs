namespace Octo.Net.Data1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFileUploadTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        ContentType = c.String(),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        ArtworkId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblArtworks", t => t.ArtworkId, cascadeDelete: true)
                .ForeignKey("dbo.tblUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ArtworkId);
            
            DropColumn("dbo.tblArtworks", "ArtworkImagePath");
            DropColumn("dbo.tblUsers", "UserProfileImagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblUsers", "UserProfileImagePath", c => c.String());
            AddColumn("dbo.tblArtworks", "ArtworkImagePath", c => c.String());
            DropForeignKey("dbo.tblFiles", "UserId", "dbo.tblUsers");
            DropForeignKey("dbo.tblFiles", "ArtworkId", "dbo.tblArtworks");
            DropIndex("dbo.tblFiles", new[] { "ArtworkId" });
            DropIndex("dbo.tblFiles", new[] { "UserId" });
            DropTable("dbo.tblFiles");
        }
    }
}
