﻿using System.IO;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ModularMonolith.Modules.Conferences.Core.Entities;

namespace ModularMonolith.Modules.Conferences.Core.DAL
{
    public class ConferencesDbContext : DbContext
    {
        public DbSet<Conference> Conferences { get; set; }
        public DbSet<Host> Hosts { get; set; }

        public ConferencesDbContext(DbContextOptions<ConferencesDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("conferences");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}