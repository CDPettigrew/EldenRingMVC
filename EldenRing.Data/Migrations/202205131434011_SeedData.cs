namespace EldenRing.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Spell", "Image", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Spell", "Image");
        }
    }
}
