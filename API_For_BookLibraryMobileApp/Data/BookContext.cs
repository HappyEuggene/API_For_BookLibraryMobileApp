using Microsoft.EntityFrameworkCore;
using API_For_BookLibraryMobileApp.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace API_For_BookLibraryMobileApp.Data
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public BookContext(DbContextOptions<BookContext> options) : base(options) { }

        // Перевизначення методу OnModelCreating для налаштування моделей
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Налаштування для моделі Book (можна додати інші налаштування за необхідністю)
            modelBuilder.Entity<Book>().HasKey(b => b.Id);
            modelBuilder.Entity<Book>().Property(b => b.Author).IsRequired();
            modelBuilder.Entity<Book>().Property(b => b.Title).IsRequired();
            modelBuilder.Entity<Book>().Property(b => b.PublisherAddress).IsRequired();
        }
    }
}
