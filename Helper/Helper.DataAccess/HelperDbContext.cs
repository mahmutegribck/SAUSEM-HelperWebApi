using Helper.Entites.Entites;
using Helper.Entites.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helper.DataAccess
{
    public class HelperDbContext : IdentityDbContext
    {
        public HelperDbContext() { }
        public HelperDbContext(DbContextOptions dbContext) : base(dbContext) { }  

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-P4A4V8S; Database=HelperDb; Trusted_Connection=True;");

        }

        //public DbSet<ApplicationUser> applicationUsers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Help> Helps { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Answer> Answers { get; set; }
    }
}
