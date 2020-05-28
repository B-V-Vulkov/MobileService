namespace MobileService.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DeviceModels")]
    public class DeviceModel
    {
        public DeviceModel()
        {
            this.Orders = new HashSet<Order>();
            this.RepairPrices = new HashSet<RepairPrice>();
        }

        [Required]
        public int DeviceModelId { get; set; }

        [Required]
        [MaxLength(100)]
        public string DeviceModelName { get; set; }

        public IEnumerable<Order> Orders { get; set; }

        public IEnumerable<RepairPrice> RepairPrices { get; set; }
    }
}
