﻿using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.DB
{
    public class TestDbContext : DbContext
    {
        public DbSet<A> As { get; set; }
        public DbSet<B> Bs { get; set; }

        public TestDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=test.db");

            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



        }
    }
}
