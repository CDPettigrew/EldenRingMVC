namespace EldenRing.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedData2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Spell", "SpellId", "dbo.Weapon");
            DropIndex("dbo.Spell", new[] { "SpellId" });
            DropPrimaryKey("dbo.Spell");
            AlterColumn("dbo.Spell", "SpellId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Spell", "SpellId");
            CreateIndex("dbo.Weapon", "SpellId");
            AddForeignKey("dbo.Weapon", "SpellId", "dbo.Spell", "SpellId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Weapon", "SpellId", "dbo.Spell");
            DropIndex("dbo.Weapon", new[] { "SpellId" });
            DropPrimaryKey("dbo.Spell");
            AlterColumn("dbo.Spell", "SpellId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Spell", "SpellId");
            CreateIndex("dbo.Spell", "SpellId");
            AddForeignKey("dbo.Spell", "SpellId", "dbo.Weapon", "WeaponId");
        }
    }
}
