namespace MobileService.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class EmployeePositionConfiguration : IEntityTypeConfiguration<EmployeePosition>
    {
        public void Configure(EntityTypeBuilder<EmployeePosition> builder)
        {
            builder.HasKey(key => key.EmployeePositionId);
        }
    }
}
