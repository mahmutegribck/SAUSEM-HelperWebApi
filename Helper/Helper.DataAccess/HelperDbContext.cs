using Helper.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helper.DataAccess
{
    public class HelperDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-P4A4V8S; Database=HelperDb; Trusted_Connection=True;");

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Help> Helps { get; set; }
    }
}
