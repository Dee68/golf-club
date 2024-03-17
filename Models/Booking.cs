namespace GolfClub.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime TeeTime { get; set; }
        // Player 1 details
        public int Player1GolferId { get; set; }
        public Golfer? Player1 { get; set; }
        

        // Player 2 details
        public int Player2GolferId { get; set; }
        public Golfer? Player2 { get; set; }
        

        // Player 3 details
        public int Player3GolferId { get; set; }
        public Golfer? Player3 { get; set; }
        

        // Player 4 details
        public int Player4GolferId { get; set; }
        public Golfer? Player4 { get; set; }
        

        //Foreign key for associated golfer,
        //one that does the booking(the one the booking is assigned to)
        public int GolferId { get; set; }

        public Golfer? Golfer { get; set; }
    }
}
