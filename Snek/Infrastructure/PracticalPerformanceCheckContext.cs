using DocumentFormat.OpenXml.Bibliography;
using Microsoft.EntityFrameworkCore;
using Snek.Graph_Creation.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snek.Infrastructure
{
    public class PracticalPerformanceCheckContext : DbContext
    {
        public PracticalPerformanceCheckContext()
        { }

        public PracticalPerformanceCheckContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<Mitwirkende> Mitwirkende => Set<Mitwirkende>();
        public DbSet<Arbeiten> Arbeiten => Set<Arbeiten>();
        public DbSet<Zeiten> Zeiten => Set<Zeiten>();
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(@"Data Source=Snek.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { }
    }
}