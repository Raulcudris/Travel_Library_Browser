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
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(e => e.Isbn)
                   .HasName("PK__libros__447D36EB4B0E3945");

            builder.ToTable("libros");

            builder.Property(e => e.Isbn)
                .ValueGeneratedNever()
                .HasColumnName("ISBN");

            builder.Property(e => e.EditorId).HasColumnName("editoriales_id");

            builder.Property(e => e.NPages)
                .IsRequired()
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("n_paginas");

            builder.Property(e => e.Synopsis)
                .IsRequired()
                .HasColumnType("text")
                .HasColumnName("sinopsis");

            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("titulo");

            builder.HasOne(d => d.Editorials)
                .WithMany(p => p.Books)
                .HasForeignKey(d => d.EditorId)
                .HasConstraintName("FK_libros_editoriales");
        }
    }
}
