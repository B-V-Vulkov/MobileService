namespace MobileService.ViewModels.CheckOrder
{
    using System.ComponentModel.DataAnnotations;

    public class CheckOrderViewModel
    {
        [Required(ErrorMessage = "Order number is required")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "Order number must be exactly 8 characters")]
        public string OrderNumber { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "Password must be exactly 8 characters")]
        public string OrderPassword { get; set; }
    }
}
