using Microsoft.EntityFrameworkCore;
using MovieApi.Models;
using System;
using System.Collections.Generic;

namespace MovieApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var MovieList = new Movie[]
            {
                new Movie { id = 1,title = "Pengabdi Setan 2", description = "Film Horor tahun2022", rating = Convert.ToSingle(7.0), image = "", created_at = DateTime.Now, updated_at = DateTime.Now}
            };
            modelBuilder.Entity<Movie>().HasData(MovieList);
        }
    }
}
