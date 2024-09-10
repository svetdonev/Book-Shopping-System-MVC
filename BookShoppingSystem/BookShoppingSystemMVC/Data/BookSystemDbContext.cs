﻿using BookShoppingSystemMVC.Models;
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

        public DbSet<Book> Books { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    }
}
