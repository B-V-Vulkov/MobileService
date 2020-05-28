namespace MobileService.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class RepairPriceConfiguration : IEntityTypeConfiguration<RepairPrice>
    {
        public void Configure(EntityTypeBuilder<RepairPrice> builder)
        {
            builder.HasKey(key => new { key.DeviceModelId, key.RepairTypeId });

            builder
                .HasOne(fk => fk.DeviceModel)
                .WithMany(fk => fk.RepairPrices)
                .HasForeignKey(fk => fk.DeviceModelId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(fk => fk.RepairType)
                .WithMany(fk => fk.RepairPrices)
                .HasForeignKey(fk => fk.RepairTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
