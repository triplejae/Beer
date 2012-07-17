using System;
using System.Collections.Generic;
using System.Data.Entity;
using Beer.Models;
using Beer.DAL;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Beer.Models
{
    public class BeerContext : DbContext
    {
        public DbSet<StyleguideClass> StyleguideClasses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategorys { get; set; }
        public DbSet<Brewery> Breweries { get; set; }
        public DbSet<BeerItem> Beers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}