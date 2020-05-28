namespace MobileService.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class DeviceModelConfiguration : IEntityTypeConfiguration<DeviceModel>
    {
        public void Configure(EntityTypeBuilder<DeviceModel> builder)
        {
            builder.HasKey(key => key.DeviceModelId);
        }
    }
}
