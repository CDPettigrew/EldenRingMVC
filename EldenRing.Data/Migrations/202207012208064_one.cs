namespace EldenRing.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class one : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArmorSets",
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
                .ForeignKey("dbo.Locations", t => t.LocationId)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Region = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.LocationId);
            
            CreateTable(
                "dbo.Spells",
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
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.SpellId)
                .ForeignKey("dbo.Locations", t => t.LocationId)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.Weapons",
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
                .ForeignKey("dbo.Locations", t => t.LocationId)
                .ForeignKey("dbo.Spells", t => t.SpellId)
                .Index(t => t.LocationId)
                .Index(t => t.SpellId);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUsers",
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
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRoles", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserLogins", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserClaims", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropForeignKey("dbo.Weapons", "SpellId", "dbo.Spells");
            DropForeignKey("dbo.Weapons", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Spells", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.ArmorSets", "LocationId", "dbo.Locations");
            DropIndex("dbo.IdentityUserLogins", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Weapons", new[] { "SpellId" });
            DropIndex("dbo.Weapons", new[] { "LocationId" });
            DropIndex("dbo.Spells", new[] { "LocationId" });
            DropIndex("dbo.ArmorSets", new[] { "LocationId" });
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.Weapons");
            DropTable("dbo.Spells");
            DropTable("dbo.Locations");
            DropTable("dbo.ArmorSets");
        }
    }
}
