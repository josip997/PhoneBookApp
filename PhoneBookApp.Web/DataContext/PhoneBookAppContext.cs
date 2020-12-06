using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using PhoneBookApp.Web.Models;

namespace PhoneBookApp.Web.DataContext
{
    public class PhoneBookAppContext : DbContext
    {
        public PhoneBookAppContext(DbContextOptions<PhoneBookAppContext > options):base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=DESKTOP-D1R32M0; Initial Catalog=TestPhoneBookApp; User Id=sa; Password=12!?qwQW;");
        //}
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Person> People { get; set; }
        protected override void OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>(options =>
            {
                options.HasData(
                    new Country
                    {
                        Id = 1,
                        Name = "BiH"
                    },
                    new Country
                    {
                        Id =2,
                        Name = "Croatia"
                    },
                    new Country
                    {
                        Id = 3,
                        Name = "Serbia"
                    });
            });
            modelBuilder.Entity<City>(options =>
            {
                options.HasData(
                    new City
                    {
                        Id = 1,
                        CountryId = 1,
                        Name = "Tuzla"
                    },
                    new City
                    {
                        Id = 2,
                        CountryId = 1,
                        Name = "Lukavac"
                    },
                    new City
                    {
                        Id = 3,
                        CountryId = 2,
                        Name = "Zagreb"
                    },
                    new City
                    {
                        Id = 4,
                        CountryId = 2,
                        Name = "Split"
                    },
                    new City
                    {
                        Id = 5,
                        CountryId = 3,
                        Name = "Belgrade"
                    },
                    new City
                    {
                        Id = 6,
                        CountryId = 3,
                        Name = "Niš"
                    });
            });
        }
    }
}
