using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Travel_Library.Core.Entities;
using Travel_Library.Infrastructure.Data.Configurations;

#nullable disable

namespace Travel_Library.Infrastructure.Data
{
    public partial class TRAVELContext : DbContext
    {
        public TRAVELContext()
        {
        }

        public TRAVELContext(DbContextOptions<TRAVELContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Authors> Authors { get; set; }
        public virtual DbSet<Author_has_Books> Author_Has_Books { get; set; }
        public virtual DbSet<Editorials> Editorials { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Security> Securities { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            /*modelBuilder.ApplyConfiguration(new AuthorsConfiguration());
            modelBuilder.ApplyConfiguration(new Author_has_BookConfiguration());
            modelBuilder.ApplyConfiguration(new EditorialConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new SecurityConfiguration());*/

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
      }
}
