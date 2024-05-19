using Microsoft.EntityFrameworkCore;
using Procesio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procesio.Infrastructure.EntityConfigurations
{
    internal class ProcessConfiguration : IEntityTypeConfiguration<Process>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Process> builder)
        {
            builder.ToTable("Processes");

            builder.HasIndex(e => e.Id)
                .HasDatabaseName("ID_PROCESSES");

            builder.Property(e => e.CreatedAt).HasColumnType("datetime");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
            
        }
    }
}
