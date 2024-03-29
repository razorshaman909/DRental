﻿namespace DRental.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        public string? StoreName { get; set; }
        public string? Address { get; set; }

        public IList<Member>? Members { get; set; }

        public IList<Stock>? Stocks { get; set; }

        public IList<Order>? Order { get; set; }
    }
}
