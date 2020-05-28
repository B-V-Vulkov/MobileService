namespace MobileService.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("RepairPrices")]
    public class RepairPrice
    {
        [Required]
        public int DeviceModelId { get; set; }

        public DeviceModel DeviceModel { get; set; }
        
        [Required]
        public int RepairTypeId { get; set; }

        public RepairType RepairType { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
