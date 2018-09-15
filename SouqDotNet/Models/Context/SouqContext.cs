using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//
using System.Data.Entity;
using SouqDotNet.Models.Entities;
namespace SouqDotNet.Models.Context
{
    public class SouqContext: DbContext
    {
        public SouqContext():base("name=SouqModel")
        {
            //this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>().HasKey(k => new { k.OrderId,k.ProductId });
            modelBuilder.Entity<Product>().Ignore(t => t.FilePhoto);
        }
    }
}