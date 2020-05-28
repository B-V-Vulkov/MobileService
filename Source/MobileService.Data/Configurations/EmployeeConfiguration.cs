namespace MobileService.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(key => key.EmployeeId);

            builder
                .HasOne(fk => fk.EmployeePosition)
                .WithMany(fk => fk.Employees)
                .HasForeignKey(fk => fk.EmployeePositionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasIndex(i => i.Email)
                .IsUnique(true);

            builder
                .HasIndex(i => i.Password)
                .IsUnique(false);
        }
    }
}
