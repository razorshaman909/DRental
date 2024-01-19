namespace DRental.Models
{
    public class StockCount
    {
        public int Id { get; set; }

        public int Count { get; set; } = 1;



        public int? LocationId { get; set; }
        public Location? Location { get; set; }
    }
}
