using System;
using Microsoft.EntityFrameworkCore;
using Trakmus.api.DAL.Models;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

/// <summary>
/// https://www.youtube.com/watch?v=pb218L_-0pk
/// https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
/// https://code-maze.com/net-core-web-development-part3/
/// </summary>

namespace Trakmus.api.DAL
{

    public interface ITrakMusContext : IDisposable
    {
        DbSet<Tractor> Tractors { get; set; }
        DbSet<VehicleModel> VehicleModels { get; set; }

        DbSet<Manufacturer> Manufacturers { get; set; }

        DbSet<User> Users { get; set; }


        int SaveChanges();
    }

    public class TrakMusContext : DbContext
    {

        public TrakMusContext(DbContextOptions<TrakMusContext> options) : base(options)
        { 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        //entities
        public DbSet<Tractor> Tractors { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Person> Persons { get; set; }

        
    }
}
