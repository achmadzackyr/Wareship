using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Wareship.Model.User;

namespace Wareship.Authentication
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            this.SeedUserStatus(builder);
            this.SeedUserTier(builder);
            this.SeedRoles(builder);
            this.SeedUsers(builder);
            this.SeedUserRoles(builder);
        }

        private void SeedUserStatus(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>()
            .HasOne(p => p.UserStatus)
            .WithMany(b => b.Users);

            builder.Entity<UserStatus>().HasData(
                new UserStatus { Id = 1, Name = "Active" },
                new UserStatus { Id = 2, Name = "Suspended" },
                new UserStatus { Id = 3, Name = "Banned" }
                );
        }

        private void SeedUserTier(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>()
            .HasOne(p => p.UserTier)
            .WithMany(b => b.Users);

            builder.Entity<UserTier>().HasData(
                new UserTier { Id = 1, Name = "Rookie" },
                new UserTier { Id = 2, Name = "Champion" },
                new UserTier { Id = 3, Name = "Ultimate" },
                new UserTier { Id = 4, Name = "Mega" }
                );
        }

        private void SeedUsers(ModelBuilder builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                    {
                        UserStatusId = 1,
                        UserTierId = 1,
                        Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                        UserName = "admin",
                        SecurityStamp = Guid.NewGuid().ToString(),
                        Email = "admin@example.com",
                        NormalizedEmail = "ADMIN@EXAMPLE.COM",
                        Name = "Admin Suradmin",
                        PhoneNumber = "085223670378",
                        Dob = Convert.ToDateTime("1989-12-07"),
                        Street = "Dusun Desa, Desa Cijeungjing",
                        Subdistrict = "Cijeungjing",
                        City = "Kabupaten Ciamis",
                        Province = "Jawa Barat",
                        Gender = "Laki-Laki",
                        ProfilePictureUrl = "https://images.pexels.com/photos/6652928/pexels-photo-6652928.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                        CreatedAt = DateTime.Now,
                        CreatedBy = null,
                        NormalizedUserName = "ADMIN",
                        PasswordHash = hasher.HashPassword(null, "Admin123!")
                    },
                new ApplicationUser
                    {
                        UserStatusId = 1,
                        UserTierId = 2,
                        Id = "supplier-6340-4840-95c2-db12554843e5",
                        UserName = "supplier",
                        SecurityStamp = Guid.NewGuid().ToString(),
                        Email = "supplier@example.com",
                        NormalizedEmail = "SUPPLIER@EXAMPLE.COM",
                        Name = "Susu Plier",
                        PhoneNumber = "085223670378",
                        Dob = Convert.ToDateTime("1989-12-07"),
                        Street = "Dusun Desa, Desa Cijeungjing",
                        Subdistrict = "Cijeungjing",
                        City = "Kabupaten Ciamis",
                        Province = "Jawa Barat",
                        Gender = "Laki-Laki",
                        ProfilePictureUrl = "https://images.pexels.com/photos/6652928/pexels-photo-6652928.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                        CreatedAt = DateTime.Now,
                        CreatedBy = null,
                        NormalizedUserName = "SUPPLIER",
                        PasswordHash = hasher.HashPassword(null, "Supplier123!")
                    }
            );
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = "Wareshouse", ConcurrencyStamp = "2", NormalizedName = "Wareshouse" },
                new IdentityRole() { Id = "b7b013f0-5201-4317-abd8-c211f91b7660", Name = "Supplier", ConcurrencyStamp = "3", NormalizedName = "Supplier" },
                new IdentityRole() { Id = "a7b013f0-5201-4317-abd8-c211f91b7990", Name = "Dropshipper", ConcurrencyStamp = "4", NormalizedName = "Dropshipper" }
                );
        }

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" },
                new IdentityUserRole<string>() { RoleId = "b7b013f0-5201-4317-abd8-c211f91b7660", UserId = "supplier-6340-4840-95c2-db12554843e5" }
                );
        }
    }
}
