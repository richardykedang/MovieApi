using System.ComponentModel.DataAnnotations;

namespace MovieApi.Models
{
    public class MovieCreateRequest
    {
        public string title { get; set; }
        
        public string description { get; set; }
        
        public float rating { get; set; }
        
        //public string image { get; set; }
        public IFormFile img { get; set; }
       

    }

    public class MovieUpdateRequest
    {
        public string title { get; set; }

        public string description { get; set; }

        public float rating { get; set; }

        //public string image { get; set; }
        public IFormFile img { get; set; }
        //public string image_path { get; set; }

    }
}
