using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace VVBData.Models
{
    public class VVBDbContext : DbContext
    {
        public DbSet<Klant> Klanten { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Verhuring> Verhuringen { get; set; }


        public VVBDbContext() { }
        public VVBDbContext(DbContextOptions options) : base(options) { }
    }
}
