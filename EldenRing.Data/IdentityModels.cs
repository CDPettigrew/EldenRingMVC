﻿using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using EldenRing.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EldenRing.WebMVC.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<ArmorSet> ArmorSets { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Spell> Spells { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Weapon>()
                .HasRequired(l => l.Location)
                .WithMany()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Weapon>()
                .HasRequired(s => s.Spell)
                .WithMany()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<ArmorSet>()
                .HasRequired(l => l.Location)
                .WithMany()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Spell>()
                .HasRequired(l => l.Location)
                .WithMany()
                .WillCascadeOnDelete(false);*/
            /*modelBuilder
                .Conventions
                .Remove<PluralizingTableNameConvention>();*/
            modelBuilder
                .Configurations
                .Add(new IdentityUserLoginConfiguration())
                .Add(new IdentityUserRoleConfiguration());
        }
    }
    public class IdentityUserLoginConfiguration : EntityTypeConfiguration<IdentityUserLogin>
    {
        public IdentityUserLoginConfiguration()
        {
            HasKey(IdentityUserLogin => IdentityUserLogin.UserId);
        }
    }
    public class IdentityUserRoleConfiguration : EntityTypeConfiguration<IdentityUserRole>
    {
        public IdentityUserRoleConfiguration()
        {
            HasKey(iur => iur.UserId);
        }
    }
}