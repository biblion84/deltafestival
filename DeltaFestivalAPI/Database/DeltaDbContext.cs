using Microsoft.EntityFrameworkCore;
using DeltaFestivalAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DeltaFestivalAPI.Database
{
    public class DeltaDbContext : DbContext
    {

        public DeltaDbContext(DbContextOptions<DeltaDbContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
        }

       
        public DbSet<Publication> Publications { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Mood> Moods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
