using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Travel_Library.Core.Entities;

namespace Travel_Library.Infrastructure.Data.Configurations
{
    public class Author_has_BookConfiguration : IEntityTypeConfiguration<Author_has_Books>
    {
        public void Configure(EntityTypeBuilder<Author_has_Books> builder)
        {
            builder.HasNoKey();

            builder.ToTable("autores_has_libros");

            builder.Property(e => e.AuthorsId).HasColumnName("autores_id");

            builder.Property(e => e.BookIsbn).HasColumnName("libro_ISBN");

            builder.HasOne(d => d.Authors)
                .WithMany()
                .HasForeignKey(d => d.AuthorsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_autores_has_libros_autores");

            builder.HasOne(d => d.BookIsbnNavigation)
                .WithMany()
                .HasForeignKey(d => d.BookIsbn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_autores_has_libros_libros");
        }
    }
}
