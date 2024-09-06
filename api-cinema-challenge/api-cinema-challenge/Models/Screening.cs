using System.ComponentModel.DataAnnotations.Schema;

namespace api_cinema_challenge.Models
{
    [Table("Screenings")]
    public class Screening
    {
        [Column("Id")]
        public int Id { get; set; }

        [ForeignKey("Movie")]
        [Column("MovieId")]
        public int MovieId { get; set; }
        public Movie movie { get; set; }    
        [Column("ScreenNumber")]
        public int ScreenNumber { get; set; }
        [Column("Capacity")]
        public int Capacity { get; set; }
        [Column("StartsAt")]
        public string StartsAt { get; set; }
    }
}
