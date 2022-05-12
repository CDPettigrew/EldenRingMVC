namespace EldenRing.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArmorSet",
                c => new
                    {
                        ArmorSetId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        TypeOfArmor = c.Int(nullable: false),
                        Pieces = c.String(nullable: false),
                        PhysicalProtection = c.Double(nullable: false),
                        MagicProtection = c.Double(nullable: false),
                        FireProtection = c.Double(nullable: false),
                        LightProtection = c.Double(nullable: false),
                        HolyProtection = c.Double(nullable: false),
                        LocationId = c.Int(),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.ArmorSetId)
                .ForeignKey("dbo.Location", t => t.LocationId)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Region = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.LocationId);
            
            CreateTable(
                "dbo.Spell",
                c => new
                    {
                        SpellId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        TypeOfSpell = c.Int(nullable: false),
                        Incantation = c.Boolean(nullable: false),
                        Scorcery = c.Boolean(nullable: false),
                        FocusPoints = c.Int(nullable: false),
                        SlotUsage = c.Int(nullable: false),
                        IntelligenceScaling = c.Double(nullable: false),
                        FaithScaling = c.Double(nullable: false),
                        ArcaneScaling = c.Double(nullable: false),
                        LocationId = c.Int(),
                    })
                .PrimaryKey(t => t.SpellId)
                .ForeignKey("dbo.Location", t => t.LocationId)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.Weapon",
                c => new
                    {
                        WeaponId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        TypeOfWeapon = c.Int(nullable: false),
                        StrengthScaling = c.String(nullable: false),
                        DexterityScaling = c.String(nullable: false),
                        IntelligenceScaling = c.String(nullable: false),
                        FaithScaling = c.String(nullable: false),
                        ArcaneScaling = c.String(nullable: false),
                        PhysicalDamage = c.String(nullable: false),
                        MagicDamage = c.String(nullable: false),
                        FireDamage = c.String(nullable: false),
                        LightDamage = c.String(nullable: false),
                        HolyDamage = c.String(nullable: false),
                        Bleed = c.Boolean(nullable: false),
                        Poison = c.Boolean(nullable: false),
                        FrostBite = c.Boolean(nullable: false),
                        ScarletRot = c.Boolean(nullable: false),
                        Sleep = c.Boolean(nullable: false),
                        Madness = c.Boolean(nullable: false),
                        Image = c.Binary(),
                        LocationId = c.Int(),
                        SpellId = c.Int(),
                    })
                .PrimaryKey(t => t.WeaponId)
                .ForeignKey("dbo.Location", t => t.LocationId)
                .ForeignKey("dbo.Spell", t => t.SpellId)
                .Index(t => t.LocationId)
                .Index(t => t.SpellId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Weapon", "SpellId", "dbo.Spell");
            DropForeignKey("dbo.Weapon", "LocationId", "dbo.Location");
            DropForeignKey("dbo.Spell", "LocationId", "dbo.Location");
            DropForeignKey("dbo.ArmorSet", "LocationId", "dbo.Location");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Weapon", new[] { "SpellId" });
            DropIndex("dbo.Weapon", new[] { "LocationId" });
            DropIndex("dbo.Spell", new[] { "LocationId" });
            DropIndex("dbo.ArmorSet", new[] { "LocationId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Weapon");
            DropTable("dbo.Spell");
            DropTable("dbo.Location");
            DropTable("dbo.ArmorSet");
        }
    }
}
