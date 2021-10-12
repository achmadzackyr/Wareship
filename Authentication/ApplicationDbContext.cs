using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Wareship.Model.Products;
using Wareship.Model.Stocks;
using Wareship.Model.Transactions;
using Wareship.Model.Users;

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
            this.SeedAddress(builder);
            this.SeedProductStatus(builder);
            this.SeedCategory(builder);
            this.SeedSubCategory(builder);
            this.SeedWarehouse(builder);
            this.SeedVariation(builder);
            this.SeedOption(builder);
            this.SeedCourier(builder);
            this.SeedDeliveryService(builder);
            this.SeedTransactionStatus(builder);
            this.SeedPayment(builder);
            this.SeedShipper(builder);
            this.SeedConsignee(builder);

            this.SeedUsers(builder);
            this.SeedUserRoles(builder);
            this.SeedUserAddress(builder);
            this.SeedProduct(builder);
            this.SeedProductImage(builder);
            this.SeedStock(builder);
            this.SeedCart(builder);
            this.SeedCartDetail(builder);
            this.SeedTransaction(builder);
            this.SeedOrder(builder);
            this.SeedUserTransaction(builder);
        }


        private void SeedCart(ModelBuilder builder)
        {
            builder.Entity<Cart>()
            .HasOne(s => s.User)
            .WithOne()
            .OnDelete(DeleteBehavior.Restrict);
        }

        private void SeedCartDetail(ModelBuilder builder)
        {
            builder.Entity<CartDetail>()
            .HasOne(p => p.Cart)
            .WithMany(b => b.CartDetails);

            builder.Entity<CartDetail>()
            .HasOne(p => p.Stock)
            .WithMany(b => b.CartDetails);
        }

        private void SeedProductImage(ModelBuilder builder)
        {
            var productImgList = new List<ProductImage>();
            for (int i = 1; i <= 10; i++)
            {
                productImgList.Add(
                new ProductImage
                {
                    Id = i,
                    CreatedAt = DateTime.Now,
                    ProductId = i,
                    Filename = "https://images.pexels.com/photos/762687/pexels-photo-762687.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940"
                });
            }

            builder.Entity<ProductImage>().HasData(productImgList);

        }

        private void SeedUserTransaction(ModelBuilder builder)
        {
            builder.Entity<Transaction>()
            .HasOne(p => p.User)
            .WithMany(b => b.Transactions);
        }

        private void SeedOrder(ModelBuilder builder)
        {
        }

        private void SeedTransaction(ModelBuilder builder)
        {
            builder.Entity<Order>()
            .HasOne(p => p.Transaction)
            .WithMany(b => b.Orders);

            builder.Entity<Transaction>()
            .HasOne(p => p.Shipper)
            .WithMany(b => b.Transactions);

            builder.Entity<Transaction>()
            .HasOne(p => p.Consignee)
            .WithMany(b => b.Transactions);
        }

        private void SeedShipper(ModelBuilder builder)
        {
            builder.Entity<Transaction>()
            .HasOne(p => p.Shipper)
            .WithMany(b => b.Transactions);

            builder.Entity<Shipper>()
            .HasOne(s => s.Address)
            .WithOne()
            .OnDelete(DeleteBehavior.Restrict);
        }

        private void SeedConsignee(ModelBuilder builder)
        {
            builder.Entity<Transaction>()
            .HasOne(p => p.Consignee)
            .WithMany(b => b.Transactions);

            builder.Entity<Consignee>()
            .HasOne(s => s.Address)
            .WithOne()
            .OnDelete(DeleteBehavior.Restrict);
        }

        private void SeedPayment(ModelBuilder builder)
        {
            builder.Entity<Transaction>()
            .HasOne(p => p.Payment)
            .WithMany(b => b.Transactions);

            builder.Entity<Payment>().HasData(
                new Payment { Id = 1, Name = "Bank Transfer" },
                new Payment { Id = 2, Name = "Cash on Delivery" },
                new Payment { Id = 3, Name = "Paylater" }
                );
        }

        private void SeedTransactionStatus(ModelBuilder builder)
        {
            builder.Entity<Transaction>()
            .HasOne(p => p.TransactionStatus)
            .WithMany(b => b.Transactions);

            builder.Entity<TransactionStatus>().HasData(
                new TransactionStatus { Id = 1, Name = "Pending"},
                new TransactionStatus { Id = 2, Name = "Accepted"},
                new TransactionStatus { Id = 3, Name = "Processed"},
                new TransactionStatus { Id = 4, Name = "Delivered"},
                new TransactionStatus { Id = 5, Name = "Cancelled"}
                );
        }

        private void SeedDeliveryService(ModelBuilder builder)
        {
            builder.Entity<Transaction>()
            .HasOne(p => p.DeliveryService)
            .WithMany(b => b.Transactions);

            builder.Entity<DeliveryService>().HasData(
                new DeliveryService {Id = 1, Name = "REG", CourierId = 1},
                new DeliveryService {Id = 2, Name = "YES", CourierId = 1},
                new DeliveryService {Id = 3, Name = "OKE", CourierId = 1},
                new DeliveryService {Id = 4, Name = "JTR", CourierId = 1}
                );
        }

        private void SeedCourier(ModelBuilder builder)
        {
            builder.Entity<DeliveryService>()
            .HasOne(p => p.Courier)
            .WithMany(b => b.DeliveryServices);

            builder.Entity<Courier>().HasData(
                new Courier
                {
                    Id = 1,
                    Name = "JNE"
                }
                );
        }

        private void SeedStock(ModelBuilder builder)
        {
            builder.Entity<Order>()
            .HasOne(p => p.Stock)
            .WithMany(b => b.Orders);
        }

        private void SeedWarehouse(ModelBuilder builder)
        {
            builder.Entity<Stock>()
            .HasOne(p => p.Warehouse)
            .WithMany(b => b.Stocks);

            builder.Entity<Warehouse>()
            .HasOne(s => s.Address)
            .WithOne()
            .OnDelete(DeleteBehavior.Restrict);
        }

        private void SeedOption(ModelBuilder builder)
        {
            builder.Entity<Stock>()
            .HasOne(p => p.Option)
            .WithMany(b => b.Stocks);

            builder.Entity<Option>().HasData(
                new Option { Id = 1, Name = "38", VariationId = 1 },
                new Option { Id = 2, Name = "39", VariationId = 1 },
                new Option { Id = 3, Name = "40", VariationId = 1 },
                new Option { Id = 4, Name = "41", VariationId = 1 },
                new Option { Id = 5, Name = "42", VariationId = 1 },
                new Option { Id = 6, Name = "43", VariationId = 1 },
                new Option { Id = 7, Name = "Hitam", VariationId = 2 },
                new Option { Id = 8, Name = "Putih", VariationId = 2 },
                new Option { Id = 9, Name = "Merah", VariationId = 2 },
                new Option { Id = 10, Name = "Biru", VariationId = 2 },
                new Option { Id = 11, Name = "Pink", VariationId = 2 },
                new Option { Id = 12, Name = "Kuning", VariationId = 2 }
                );
        }

        private void SeedVariation(ModelBuilder builder)
        {
            builder.Entity<Option>()
            .HasOne(p => p.Variation)
            .WithMany(b => b.Options);

            builder.Entity<Variation>().HasData(
                new Variation { Id = 1, Name = "Ukuran" },
                new Variation { Id = 2, Name = "Warna" }
                );
        }

        private void SeedProduct(ModelBuilder builder)
        {
            builder.Entity<ProductImage>()
            .HasOne(p => p.Product)
            .WithMany(b => b.ProductImages);

            var productSeedList = new List<Product>();
            for(int i = 1; i<=10;i++)
            {
                var productSeed = new Product
                {
                    ProductStatusId = 1,
                    SubCategoryId = 1,
                    Id = i,
                    Name = "Kamus Bahasa Inggris 1 Juta Kata",
                    Description = "Kamus Bahasa Inggris ini paling lengkap dan paling murah diantara yang lainnya",
                    Price = 100000.00,
                    Sku = "A00" + i,
                    UserId = "supplier-6340-4840-95c2-db12554843e5",
                    Volume = 1,
                    Weight = 1,
                    ChargeableWeight = 1
                };
                productSeedList.Add(productSeed);
            }

            builder.Entity<Product>().HasData(productSeedList);
        }

        private void SeedProductStatus(ModelBuilder builder)
        {
            builder.Entity<Product>()
            .HasOne(p => p.ProductStatus)
            .WithMany(b => b.Products);

            builder.Entity<ProductStatus>().HasData(
                new ProductStatus { Id = 1, Name = "Active" },
                new ProductStatus { Id = 2, Name = "Banned" },
                new ProductStatus { Id = 3, Name = "Deleted" }
                );
        }

        private void SeedCategory(ModelBuilder builder)
        {
            builder.Entity<SubCategory>()
            .HasOne(p => p.Category)
            .WithMany(b => b.SubCategories);

            builder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Buku" },
                new Category { Id = 2, Name = "Dapur" },
                new Category { Id = 3, Name = "Elektronik" },
                new Category { Id = 4, Name = "Fashion Anak & Bayi" },
                new Category { Id = 5, Name = "Fashion Muslim" },
                new Category { Id = 6, Name = "Fashion Pria" },
                new Category { Id = 7, Name = "Fashion Wanita" },
                new Category { Id = 8, Name = "Film & Musik" },
                new Category { Id = 9, Name = "Gaming" },
                new Category { Id = 10, Name = "Handphone & Tablet" }
                );
        }

        private void SeedSubCategory(ModelBuilder builder)
        {
            builder.Entity<Product>()
            .HasOne(p => p.SubCategory)
            .WithMany(b => b.Products);

            builder.Entity<SubCategory>().HasData(
                new SubCategory { Id = 1, Name = "Kamus", CategoryId = 1 },
                new SubCategory { Id = 2, Name = "Religi & Spiritual", CategoryId = 1 },
                new SubCategory { Id = 3, Name = "Peralatan Makan & Minum", CategoryId = 2 },
                new SubCategory { Id = 4, Name = "Peralatan Masak", CategoryId = 2 },
                new SubCategory { Id = 5, Name = "Alat Pendingin Ruangan", CategoryId = 3 },
                new SubCategory { Id = 6, Name = "TV & Aksesoris", CategoryId = 3 },
                new SubCategory { Id = 7, Name = "Pakaian Anak Laki-Laki", CategoryId = 4 },
                new SubCategory { Id = 8, Name = "Pakaian Anak Perempuan", CategoryId = 4 },
                new SubCategory { Id = 9, Name = "Jilbab", CategoryId = 5 },
                new SubCategory { Id = 10, Name = "Perlengkapan Ibadah", CategoryId = 5 },
                new SubCategory { Id = 11, Name = "Batik Pria", CategoryId = 6 },
                new SubCategory { Id = 12, Name = "Celana Pria", CategoryId = 6 },
                new SubCategory { Id = 13, Name = "Batik Wanita", CategoryId = 7 },
                new SubCategory { Id = 14, Name = "Bawahan Wanita", CategoryId = 7 },
                new SubCategory { Id = 15, Name = "Film & Serial", CategoryId = 8 },
                new SubCategory { Id = 16, Name = "Gitar & Bass", CategoryId = 8 },
                new SubCategory { Id = 17, Name = "CD Game", CategoryId = 9 },
                new SubCategory { Id = 18, Name = "Game Console", CategoryId = 9 },
                new SubCategory { Id = 19, Name = "Handphone", CategoryId = 10 },
                new SubCategory { Id = 20, Name = "Tablet", CategoryId = 10 }
                );
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

        private void SeedAddress(ModelBuilder builder)
        {
            builder.Entity<UserAddress>()
            .HasOne(p => p.Address)
            .WithMany(b => b.UserAddresses);

            builder.Entity<Address>().HasData(
                new Address { 
                    Id = 1,
                    Name = "Admin Suradmin",
                    Street = "Dusun Desa, Desa Cijeungjing",
                    SubdistrictId = 3207150,
                    Subdistrict = "Cijeungjing",
                    CityId = 3207,
                    City = "Kabupaten Ciamis",
                    ProvinceId = 32,
                    Province = "Jawa Barat",
                    ZipCode = "46271",
                    Phone = "085223670378"
                },
                new Address
                {
                    Id = 2,
                    Name = "Warehouse JNE Tasikmalaya",
                    Street = "Jl. Ir. H. Juanda No.21, RW.1, Cipedes",
                    SubdistrictId = 3278080,
                    Subdistrict = "Cipedes",
                    CityId = 3278,
                    City = "Kota Tasikmalaya",
                    ProvinceId = 32,
                    Province = "Jawa Barat",
                    ZipCode = "46151",
                    Phone = ""
                }
            );
        }

        private void SeedUserAddress(ModelBuilder builder)
        {
            builder.Entity<UserAddress>().HasData(
                new UserAddress
                {
                    Id = 1,
                    AddressId = 1,
                    UserId = "b74ddd14-6340-4840-95c2-db12554843e5",
                    Role = "Rumah"
                },
                new UserAddress
                {
                    Id = 2,
                    AddressId = 1,
                    UserId = "supplier-6340-4840-95c2-db12554843e5",
                    Role = "Kantor"
                }
            );
        }

        private void SeedUsers(ModelBuilder builder)
        {
            builder.Entity<Product>()
            .HasOne(p => p.User)
            .WithMany(b => b.Products);

            builder.Entity<UserAddress>()
            .HasOne(p => p.User)
            .WithMany(b => b.UserAddresses);

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

        public DbSet<Wareship.Model.Products.Category> Category { get; set; }
        public DbSet<Wareship.Model.Products.SubCategory> SubCategory { get; set; }
        public DbSet<Wareship.Model.Products.Product> Product { get; set; }
        public DbSet<Wareship.Model.Products.ProductImage> ProductImage { get; set; }
        public DbSet<Wareship.Model.Products.ProductStatus> ProductStatus { get; set; }
        public DbSet<Wareship.Model.Stocks.Warehouse> Warehouse { get; set; }
        public DbSet<Wareship.Model.Stocks.Stock> Stock { get; set; }
        public DbSet<Wareship.Model.Stocks.Option> Option { get; set; }
        public DbSet<Wareship.Model.Stocks.Variation> Variation { get; set; }
        public DbSet<Wareship.Model.Transactions.Courier> Courier { get; set; }
        public DbSet<Wareship.Model.Users.Address> Address { get; set; }
        public DbSet<Wareship.Model.Users.UserAddress> UserAddress { get; set; }

    }
}
