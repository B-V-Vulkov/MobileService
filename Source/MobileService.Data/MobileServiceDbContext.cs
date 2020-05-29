namespace MobileService.Data
{
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    using Models;

    public class MobileServiceDbContext : DbContext
    {
        public MobileServiceDbContext(DbContextOptions<MobileServiceDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<DeviceModel> DeviceModels { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeePosition> EmployeePositions { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderStatus> OrderStatuses { get; set; }

        public DbSet<RepairPrice> RepairPrices { get; set; }

        public DbSet<RepairType> RepairTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
