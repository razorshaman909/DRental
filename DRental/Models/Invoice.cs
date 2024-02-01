namespace DRental.Models
{
    public class Invoice : Order
    {
        /*Inheritence implementation using the follwoing link:
        https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/inheritance?view=aspnetcore-7.0
        */
        public int InvoiceId { get; set; }
        public DateTime? InvoiceDate { get; set; }
    }
}
