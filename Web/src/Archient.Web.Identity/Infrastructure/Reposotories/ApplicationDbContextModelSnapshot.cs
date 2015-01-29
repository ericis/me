namespace Archient.Web.Identity.Infrastructure.Repositories
{
    using Archient.Web.Identity.Domain.Entities;
    using Microsoft.AspNet.Identity;
    using Microsoft.Data.Entity;
    using Microsoft.Data.Entity.Metadata;
    using Microsoft.Data.Entity.Migrations.Infrastructure;
    using System;
    using System.Diagnostics;

    [ContextType(typeof(ApplicationDbContext))]
    public class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        public override IModel Model
        {
            get
            {
                if (Debugger.IsAttached) Debugger.Break();
                else Debugger.Launch();

                var builder = new BasicModelBuilder();

                builder.Entity(typeof(IdentityRole).FullName, b =>
                {
                    b.Property<string>("Id");
                    b.Property<string>("Name");
                    b.Key("Id");
                    b.ForRelational().Table("AspNetRoles");
                });

                builder.Entity(typeof(IdentityRoleClaim<string>).FullName, b =>
                {
                    b.Property<string>("ClaimType");
                    b.Property<string>("ClaimValue");
                    b.Property<int>("Id")
                        .GenerateValueOnAdd();
                    b.Property<string>("RoleId");
                    b.Key("Id");
                    b.ForRelational().Table("AspNetRoleClaims");
                });

                builder.Entity(typeof(IdentityUserClaim<string>).FullName, b =>
                {
                    b.Property<string>("ClaimType");
                    b.Property<string>("ClaimValue");
                    b.Property<int>("Id")
                        .GenerateValueOnAdd();
                    b.Property<string>("UserId");
                    b.Key("Id");
                    b.ForRelational().Table("AspNetUserClaims");
                });
                
                builder.Entity(typeof(IdentityUserLogin<string>).FullName, b =>
                {
                    b.Property<string>("LoginProvider");
                    b.Property<string>("ProviderDisplayName");
                    b.Property<string>("ProviderKey");
                    b.Property<string>("UserId");
                    b.Key("LoginProvider", "ProviderKey");
                    b.ForRelational().Table("AspNetUserLogins");
                });
                
                builder.Entity(typeof(IdentityUserRole<string>).FullName, b =>
                {
                    b.Property<string>("RoleId");
                    b.Property<string>("UserId");
                    b.Key("UserId", "RoleId");
                    b.ForRelational().Table("AspNetUserRoles");
                });

                builder.Entity(typeof(ApplicationUser).FullName, b =>
                {
                    b.Property<int>("AccessFailedCount");
                    b.Property<string>("Email");
                    b.Property<bool>("EmailConfirmed");
                    b.Property<string>("Id");
                    b.Property<bool>("LockoutEnabled");
                    b.Property<DateTimeOffset?>("LockoutEnd");
                    b.Property<string>("NormalizedUserName");
                    b.Property<string>("PasswordHash");
                    b.Property<string>("PhoneNumber");
                    b.Property<bool>("PhoneNumberConfirmed");
                    b.Property<string>("SecurityStamp");
                    b.Property<bool>("TwoFactorEnabled");
                    b.Property<string>("UserName");
                    b.Key("Id");
                    b.ForRelational().Table("AspNetUsers");
                });
                
                builder.Entity(typeof(IdentityRoleClaim<string>).FullName, b =>
                {
                    b.ForeignKey(typeof(IdentityRole).FullName, "RoleId");
                });
                
                builder.Entity(typeof(IdentityUserClaim<string>).FullName, b =>
                {
                    b.ForeignKey(typeof(ApplicationUser).FullName, "UserId");
                });
                
                builder.Entity(typeof(IdentityUserLogin<string>).FullName, b =>
                {
                    b.ForeignKey(typeof(ApplicationUser).FullName, "UserId");
                });

                return builder.Model;
            }
        }
    }
}