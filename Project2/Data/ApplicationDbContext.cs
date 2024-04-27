using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Project2.Models;

namespace Project2.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {

        }

        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerGroup> CustomerGroups { get; set; }
        public DbSet<OrderHed> OrderHeds { get; set; }
        public DbSet<OrderDtl> OrderDtls { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<OrderDtl>()
                .HasKey(u => new { u.OrderNumber, u.OrderLine });

            modelBuilder.Entity<OrderHed>()
                .HasMany(u => u.OrderDtls)
                .WithOne(u => u.OrderHed)
                .HasForeignKey(u => u.OrderNumber);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var propertyInfo in entityType.ClrType.GetProperties())
                {
                    if (propertyInfo.Name == "DateAdded")
                    {
                        entityType.GetProperty("DateAdded")
                            .SetDefaultValueSql("getdate()");
                    }
                }
            }
        }
    }
}