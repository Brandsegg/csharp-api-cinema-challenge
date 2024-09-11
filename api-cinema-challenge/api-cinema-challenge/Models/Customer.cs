using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_cinema_challenge.Models
{
    //[Table("customer")]
    public class Customer
    {
        [Key]
        [Column("id")]
        public int id { get; set; }
        //[Column("name")]
        public string name { get; set; }
        //[Column("email")]
        public string email { get; set; }
       // [Column("phone")]
        public string phone { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
    }
}
