namespace MobileService.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(key => key.OrderId);

            builder
                .HasOne(fk => fk.Customer)
                .WithMany(fk => fk.Orders)
                .HasForeignKey(fk => fk.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(fk => fk.Receptionist)
                .WithMany(fk => fk.ReceptionistOrders)
                .HasForeignKey(fk => fk.ReceptionistId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(fk => fk.ServiceWorker)
                .WithMany(fk => fk.ServiceWorkerOrders)
                .HasForeignKey(fk => fk.ServiceWorkerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(fk => fk.DeviceModel)
                .WithMany(fk => fk.Orders)
                .HasForeignKey(fk => fk.DeviceModelId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(fk => fk.RepairType)
                .WithMany(fk => fk.Orders)
                .HasForeignKey(fk => fk.RepairTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasIndex(i => i.OrderCode)
                .IsUnique(false);

            builder
                .HasIndex(i => i.OrderPassword)
                .IsUnique(false);
        }
    }
}
