﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Entities
{
    public class RestaurantDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Dish> Dishes { get; set; }

        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>()
                  .Property(r => r.Name)
                  .IsRequired()
                  .HasMaxLength(25);

            modelBuilder.Entity<Dish>()
                .Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(25);
        }

    }
}