using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Store.Models;

namespace Store.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Kala> Kalas { get; set; }
        public DbSet<OrderApp> OrderApps { get; set; }
        public DbSet<Store.Models.DetailKalaViewModel> DetailKalaViewModel { get; set; }
    }
}