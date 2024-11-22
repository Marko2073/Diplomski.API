
using Diplomski.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomski.DataAccess
{
    public class DatabaseContext: DbContext
    {
        public readonly string _connectionString;
        public DatabaseContext()
        {
            _connectionString = "Data Source=DESKTOP-PLR5Q1M\\SQLEXPRESS;Initial Catalog=gamingstore;Integrated Security=True;Trust Server Certificate=True";
        }
        public DatabaseContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<ModelVersion> ModelVersions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ModelVersionSpecification> ModelVersionSpecifications { get; set; }
        public DbSet<Specification> Specifications { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Price> Prices{ get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<Component> Components { get; set; }
        public DbSet<Configuration> Configurations{ get; set; }
        public DbSet<ErrorLog> ErrorLogs{ get; set; }
        public DbSet<UseCaseLog> UseCaseLogs{ get; set; }






    }
}
