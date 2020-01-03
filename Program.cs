using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Lab10_Northwind_SQLite
{
    class Program
    {
        public static List<Customer> customers = new List<Customer>();
        static void Main(string[] args)
        {
            listCustomers();
        }

        #region listCustomers
        static void listCustomers()
        {
            using (var db = new CustomerDbContext())
            {
                customers = db.Customers.Where(c=>c.City=="London").ToList();
            }
            customers.ForEach(r => Console.WriteLine($"{r.CustomerID,-10}{r.ContactName,-20}{r.Country}"));
        }
        #endregion
    }

    #region Customer Class 
    class Customer
    {
        public string CustomerID { get; set; }
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
    #endregion

    #region ConnectToDatabase
    class CustomerDbContext : DbContext
    {
        // Match TABLE Customers IN DB
        public DbSet<Customer> Customers { get; set; }

        //method to connect to database
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            //@"Data Source=C:\Users\Remus Iftimie\Engineering45\SQLite\Northwind.db
            //@"Data Source=C:\Users\Remus Iftimie\Personal_GitHub\Lab10_Northwind_SQLite\SQLite\Northwind.db"
            builder.UseSqlite(@"Data Source=C:\Users\Remus Iftimie\Personal_GitHub\Lab10_Northwind_SQLite\SQLite\Northwind.db");
        }
    }
    #endregion
}
