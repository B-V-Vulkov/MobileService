namespace MobileService.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Employees")]
    public class Employee
    {
        public Employee()
        {
            this.ReceptionistOrders = new HashSet<Order>();
            this.ServiceWorkerOrders = new HashSet<Order>();
        }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(10)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(80)]
        public string Email { get; set; }

        [Required]
        [MaxLength(80)]
        public string Password { get; set; }

        [Required]
        public int EmployeePositionId { get; set; }

        public EmployeePosition EmployeePosition { get; set; }

        public IEnumerable<Order> ReceptionistOrders { get; set; }

        public IEnumerable<Order> ServiceWorkerOrders { get; set; }
    }
}
