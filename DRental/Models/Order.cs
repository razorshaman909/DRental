using Microsoft.CodeAnalysis.CSharp;

namespace DRental.Models
{
    public abstract class Order
    {
        public int OrderId { get; set; }
        public string? OrderType { get; set; }
        public DateTime? OrderDate { get; set; }  = DateTime.Now;
        public int? LocationId { get; set; }
        public Location Location { get; set; }
        public decimal? TotalPrice { get; set;}
        public decimal? TotalItemCount { get; set;}
        public IList<OrderDetail> OrderDetails { get; set; }
    }

    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int? ItemId { get; set; }
        public Item Item { get; set; }
        public decimal? OrderPrice { get; set; }
        public int? Quantity { get; set; }
        public decimal? TotalItemPrice { get; set; }
    }
}
