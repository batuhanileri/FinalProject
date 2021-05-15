﻿using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Context :Db tabloları ile proje classlarını bağlamak
    public class NorthWindContext:DbContext
    {
        // OnConfiguring ile hangi veritabanını ilişkilendireceğimiz yer
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDb; Database=Northwind;Trusted_Connection=true");
        }
        //DbSet ile hangi nesne hangi nesneye karşılık gelicek 
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}