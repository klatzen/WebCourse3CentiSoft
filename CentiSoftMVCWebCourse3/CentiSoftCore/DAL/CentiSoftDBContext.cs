using CentiSoftCore.MODELS;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CentiSoftCore.DAL
{
    public class CentiSoftDBContext : DbContext
    {
        public CentiSoftDBContext() : base("Centisoft")
        {}

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
