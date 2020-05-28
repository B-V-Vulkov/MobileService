namespace MobileService.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("EmployeePositions")]
    public class EmployeePosition
    {
        public EmployeePosition()
        {
            this.Employees = new HashSet<Employee>();
        }

        [Required]
        public int EmployeePositionId { get; set; }

        [Required]
        [MaxLength(50)]
        public string EmployeePositionName { get; set; }

        public IEnumerable<Employee> Employees { get; set; }
    }
}
