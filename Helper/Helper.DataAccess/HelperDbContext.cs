using Helper.Entites.Entites;
using Helper.Entites.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helper.DataAccess
{
    public class HelperDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public HelperDbContext() { }
        public HelperDbContext(DbContextOptions dbContext) : base(dbContext) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-P4A4V8S; Database=HelperDb; Trusted_Connection=True;");

        }


        public DbSet<User> Users { get; set; }
        public DbSet<Help> Helps { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            this.SeedUsers(builder);
            this.SeedRoles(builder);
            this.SeedUserRoles(builder);
        }

        private void SeedUsers(ModelBuilder builder)
        {

            ApplicationUser applicationUser = new ApplicationUser()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                Name = "Admin",
                Surname = "Admin",
                UserName = "Admin",
                Email = "admin@gmail.com"

            };
            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            applicationUser.PasswordHash = passwordHasher.HashPassword(applicationUser, "Admin*123");

            builder.Entity<ApplicationUser>().HasData(applicationUser);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<ApplicationRole>().HasData(
                new ApplicationRole()
                {
                    Id = "fab4fac1-c546-41de-aebc-a14da6895711",
                    Name = "Admin",
                    ConcurrencyStamp = "1",
                    NormalizedName = "Admin"
                },
                new ApplicationRole()
                {
                    Id = "c7b013f0-5201-4317-abd8-c211f91b7330",
                    Name = "User",
                    ConcurrencyStamp = "2",
                    NormalizedName = "User"
                });
        }

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" }
                );
        }
    }
}
