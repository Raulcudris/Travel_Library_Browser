using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel_Library.Core.Entities;

namespace Travel_Library.Infrastructure.Data.Configurations
{
    public class EditorialConfiguration : IEntityTypeConfiguration<Editorials>
    {
        public void Configure(EntityTypeBuilder<Editorials> builder)
        {
            builder.ToTable("editoriales");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("nombre");

            builder.Property(e => e.Campus)
                .IsRequired()
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("sede");
        }
    }
}
