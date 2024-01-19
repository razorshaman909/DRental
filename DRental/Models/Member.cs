using System.ComponentModel.DataAnnotations.Schema;

namespace DRental.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        public string? Name { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public int LocationId { get; set; }
        public Location? RegisterLocation { get; set; }
    }
}
