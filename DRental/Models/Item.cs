namespace DRental.Models
{
    public class Item
    {
        public int ItemId { get; set; }

        public int MovieId { get; set; }
        public Movie? Movies { get; set; }

        public decimal? PurchasePrice { get; set; }

        public decimal? RentalPrice { get; set; }
    }
}
