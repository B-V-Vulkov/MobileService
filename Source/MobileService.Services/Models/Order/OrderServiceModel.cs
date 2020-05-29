namespace MobileService.Services.Models.Order
{
    public class OrderServiceModel
    {
        public int OrderId { get; set; }

        public string OrderNumber { get; set; }

        public string CustomerName { get; set; }

        public string CustomerEmail { get; set; }

        public string CustomerPhoneNumber { get; set; }

        public string Device { get; set; }

        public string Repair { get; set; }

        public string Status { get; set; }

        public string RepairDescription { get; set; }
    }
}
