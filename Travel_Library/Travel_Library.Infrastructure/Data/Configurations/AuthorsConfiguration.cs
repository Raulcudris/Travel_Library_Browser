using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travel_Library.Core.Entities;

namespace Travel_Library.Infrastructure.Data.Configurations
{
    public class AuthorsConfiguration : IEntityTypeConfiguration<Authors>
    {
      

        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Authors> builder)
        {
            builder.ToTable("autores");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("apellidos");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("nombre");
        }
    }
}
