namespace MobileService.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Orders")]
    public class Order
    {
        [Required]
        public int OrderId { get; set; }

        [Required]
        [MaxLength(8)]
        public string OrderCode { get; set; }

        [Required]
        [MaxLength(8)]
        public string OrderPassword { get; set; }

        [Required]
        public string Description { get; set; }

        public string RepairDescription { get; set; }

        [Required]
        public DateTime OrderedOn { get; set; }

        public DateTime? ReceivedForRepairOn { get; set; }

        public DateTime? RepairedOn { get; set; }

        [Required]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        [Required]
        public int ReceptionistId { get; set; }

        public Employee Receptionist { get; set; }

        public int? ServiceWorkerId { get; set; }

        public Employee ServiceWorker { get; set; }

        [Required]
        public int DeviceModelId { get; set; }

        public DeviceModel DeviceModel { get; set; }

        [Required]
        public int RepairTypeId { get; set; }

        public RepairType RepairType { get; set; }
    }
}
