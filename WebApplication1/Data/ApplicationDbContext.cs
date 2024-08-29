﻿using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }//then navigate to tools => nuget package manager=> type in console add-migration AddVillaTable
        public DbSet<Villa> Villas { get; set; } //that will be the name of the table=> then to apply these migrations run the command update-database
    }
}
