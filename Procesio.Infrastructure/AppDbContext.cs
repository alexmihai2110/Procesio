using Microsoft.EntityFrameworkCore;
using Procesio.Core.Entities;
using Procesio.Infrastructure.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procesio.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Process> Processes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProcessConfiguration());
        }
    }
}
