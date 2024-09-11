using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_cinema_challenge.Models
{
    [Table("Screenings")]
    public class Screening
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        public Movie movie { get; set; }    
        [Column("ScreenNumber")]
        public int ScreenNumber { get; set; }
        [Column("Capacity")]
        public int Capacity { get; set; }
        [Column("StartsAt")]
        public DateTime StartsAt { get; set; }

        [ForeignKey("MovieId")]
        [Column("MovieId")]
        public int MovieId { get; set; }
    }
}
