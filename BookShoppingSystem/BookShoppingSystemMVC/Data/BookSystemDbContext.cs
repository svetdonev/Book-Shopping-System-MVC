using BookShoppingSystemMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookShoppingSystemMVC.Data
{
    public class BookSystemDbContext : IdentityDbContext
    {
        public BookSystemDbContext(DbContextOptions<BookSystemDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; init; }
        public DbSet<CartDetail> CartDetails { get; init; }
        public DbSet<Genre> Genres { get; init; }
        public DbSet<Order> Orders { get; init; }
        public DbSet<OrderDetail> OrderDetails { get; init; }
        public DbSet<OrderStatus> OrderStatuses { get; init; }
        public DbSet<ShoppingCart> ShoppingCarts { get; init; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Book>()
                .HasOne(b => b.Genre)
                .WithMany(b => b.Books)
                .HasForeignKey(b => b.GenreId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
