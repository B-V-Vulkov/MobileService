namespace MobileService.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class RepairTypeConfiguration : IEntityTypeConfiguration<RepairType>
    {
        public void Configure(EntityTypeBuilder<RepairType> builder)
        {
            builder.HasKey(key => key.RepairTypeId);
        }
    }
}
