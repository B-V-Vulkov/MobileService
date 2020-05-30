namespace MobileService.Services.Models.Order
{
    public class InsertOrderServiceModel
    {
        public int DeviceModelId { get; set; }

        public int RepairTypeId { get; set; }

        public int ReceptionistId { get; set; }

        public int ServiceWorkerId { get; set; }

        public string CustomerFirstName { get; set; }

        public string CustomerMiddleName { get; set; }

        public string CustomerLastName { get; set; }

        public string CustomerPhoneNumber { get; set; }

        public string CustomerEmail { get; set; }
    }
}
