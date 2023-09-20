﻿using Microsoft.EntityFrameworkCore;
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
    }
}
