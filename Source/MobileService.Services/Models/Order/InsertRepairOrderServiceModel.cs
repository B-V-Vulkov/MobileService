namespace MobileService.Services.Models.Order
{
    public class InsertRepairOrderServiceModel
    {
        public int OrderId { get; set; }

        public int ServiceWorkerId { get; set; }

        public string RepairDescription { get; set; }
    }
}
