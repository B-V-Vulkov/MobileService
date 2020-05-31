namespace MobileService.ViewModels.Order
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class CreateOrderViewModel
    {
        public CreateOrderViewModel()
        {
            this.DeviceModels = new List<SelectListItem>();
            this.RepairTypes = new List<SelectListItem>();
            this.ServiceWorkers = new List<SelectListItem>();
        }

        [Required(ErrorMessage = "Device model is required")]
        public int DeviceModelId { get; set; }

        [Required(ErrorMessage = "Repair type is required")]
        public int RepairTypeId { get; set; }

        [Required(ErrorMessage = "Service Worker is required")]
        public int ServiceWorkerId { get; set; }

        [Required(ErrorMessage = "Customer first name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Customer first name must be between 2 and 50 characters")]
        public string CustomerFirstName { get; set; }

        [Required(ErrorMessage = "Customer middle name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Customer middle name must be between 2 and 50 characters")]
        public string CustomerMiddleName { get; set; }

        [Required(ErrorMessage = "Customer last name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Customer last name must be between 2 and 50 characters")]
        public string CustomerLastName { get; set; }

        [Required(ErrorMessage = "Customer phone number is required")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Customer phone number must be exactly 10 characters")]
        public string CustomerPhoneNumber { get; set; }

        [Required(ErrorMessage = "Customer email is required")]
        [EmailAddress(ErrorMessage = "Invalid format of email address")]
        [StringLength(80, ErrorMessage = "Customer email must be less than 80 characters")]
        public string CustomerEmail { get; set; }

        public ICollection<SelectListItem> DeviceModels { get; set; }

        public ICollection<SelectListItem> RepairTypes { get; set; }

        public ICollection<SelectListItem> ServiceWorkers { get; set; }
    }
}
