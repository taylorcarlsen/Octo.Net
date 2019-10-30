namespace Octo.Net.Data1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFlagOptions1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblFlagOptions", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblFlagOptions", "Description", c => c.String(maxLength: 25));
        }
    }
}
