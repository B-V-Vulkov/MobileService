namespace MobileService.ViewModels.Login
{
    using System.ComponentModel.DataAnnotations;

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid format of email address")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        [StringLength(80, MinimumLength = 5, ErrorMessage = "Password Must be between 5 and 80 characters")]
        public string Password { get; set; }
    }
}
