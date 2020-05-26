namespace MobileService.Data
{
    using Microsoft.EntityFrameworkCore;

    using Models;

    public class MobileServiceDbContext : DbContext
    {
        public MobileServiceDbContext(DbContextOptions<MobileServiceDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        //}
    }
}
