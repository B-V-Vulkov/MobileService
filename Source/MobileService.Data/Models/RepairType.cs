namespace MobileService.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("RepairTypes")]
    public class RepairType
    {
        public RepairType()
        {
            this.Orders = new HashSet<Order>();
            this.RepairPrices = new HashSet<RepairPrice>();
        }

        [Key]
        public int RepairTypeId { get; set; }

        [Required]
        public string RepairTypeName { get; set; }

        public IEnumerable<Order> Orders { get; set; }

        public IEnumerable<RepairPrice> RepairPrices { get; set; }
    }
}
