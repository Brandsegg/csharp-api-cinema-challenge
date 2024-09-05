using System.ComponentModel.DataAnnotations.Schema;

namespace api_cinema_challenge.Models
{
    [Table("customer")]
    public class Customer
    {
        [Column("id")]
        public int id { get; set; }
        [Column("name")]
        public string name { get; set; }
        [Column("email")]
        public string email { get; set; }
        [Column("phone")]
        public string phone { get; set; }
    }
}
