using System.ComponentModel.DataAnnotations;

namespace GolfClub.Models
{
    public enum Gender
    {
        M,
        F,
        All
    }
    public class Golfer
    {
        public int Id { get; set; }
        [Required,StringLength(15)]
        public string? FirstName { get; set; }
        [Required,StringLength(15)]
        public string? LastName { get; set; }
        [Required, EmailAddress]
        public string? EmailAddress { get; set; }
        [Required]
        public int Handicap { get; set; }
        [Required]
        public Gender Gender { get; set; }
        //Navigation property for booking
        public ICollection<Booking>? Bookings { get; set; }
    }
}
