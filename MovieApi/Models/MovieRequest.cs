using System.ComponentModel.DataAnnotations;

namespace MovieApi.Models
{
    public class MovieRequest
    {
        public string title { get; set; }
        
        public string description { get; set; }
        
        public float rating { get; set; }
        
        public string image { get; set; }

    }
}
