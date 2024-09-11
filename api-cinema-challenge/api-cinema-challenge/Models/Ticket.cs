namespace api_cinema_challenge.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int numSeats { get; set; }
        public DateTime createdAt { get; set; } = DateTime.UtcNow;
        public DateTime updatedAt { get; set; }
    }
}
