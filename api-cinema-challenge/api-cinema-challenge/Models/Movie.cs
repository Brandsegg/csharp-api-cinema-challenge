using System.ComponentModel.DataAnnotations.Schema;

namespace api_cinema_challenge.Models
{
    [Table("Movies")]
    public class Movie
    {
        [Column("id")]
        public int id { get; set; }

        [Column("title")]
        public string title { get; set; }

        [Column("rating")]
        public string rating { get; set; }

        [Column("description")]
        public string description { get; set; }

        [Column("runtimeMins")]
        public int runtimeMins { get; set; }
        
    }
}
