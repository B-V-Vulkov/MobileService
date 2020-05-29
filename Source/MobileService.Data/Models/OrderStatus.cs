namespace MobileService.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("OrderStatuses")]
    public class OrderStatus
    {
        public OrderStatus()
        {
            this.Orders = new HashSet<Order>();
        }

        [Required]
        public int OrderStatusId { get; set; }

        [Required]
        [MaxLength(20)]
        public string OrderStatusName { get; set; }

        public IEnumerable<Order> Orders { get; set; }
    }
}
