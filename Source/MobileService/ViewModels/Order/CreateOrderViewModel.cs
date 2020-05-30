namespace MobileService.ViewModels.Order
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;

    public class CreateOrderViewModel
    {
        public CreateOrderViewModel()
        {
            this.DeviceModels = new List<SelectListItem>();
            this.RepairTypes = new List<SelectListItem>();
            this.ServiceWorkers = new List<SelectListItem>();
        }

        public int DeviceModelId { get; set; }

        public int RepairTypeId { get; set; }

        public int ServiceWorkerId { get; set; }

        public string CustomerFirstName { get; set; }

        public string CustomerMiddleName { get; set; }

        public string CustomerLastName { get; set; }

        public string CustomerPhoneNumber { get; set; }

        public string CustomerEmail { get; set; }

        public ICollection<SelectListItem> DeviceModels { get; set; }

        public ICollection<SelectListItem> RepairTypes { get; set; }

        public ICollection<SelectListItem> ServiceWorkers { get; set; }
    }
}
