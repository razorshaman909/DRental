namespace DRental.Models
{
    public class Stock
    {
        public int StockId { get; set; }

        public int Count { get; set; } = 1;
        
        public int? ItemId { get; set; }
        public Item? Item { get; set; }
        public int? LocationId { get; set; }
        public Location? Location { get; set; }
    }
}
