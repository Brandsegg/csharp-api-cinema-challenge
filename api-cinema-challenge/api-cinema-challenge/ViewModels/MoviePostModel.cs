using api_cinema_challenge.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_cinema_challenge.ViewModels
{
    public class MoviePostModel
    {
        public string title { get; set; }
        
        public string rating { get; set; }

        public string description { get; set; }

        public int runtimeMins { get; set; }
        //public List<Screening> screenings { get; set; }

    }
}
