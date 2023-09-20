using System.ComponentModel.DataAnnotations;

namespace MovieApi.Models
{
    public class Movie
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Please enter the title")]
        public string title { get; set; }
        [Required(ErrorMessage = "Please enter Description")]
        public string description { get; set; }
        [Required(ErrorMessage = "Please enter the rating")]
        public float rating { get; set; }
        [Required(ErrorMessage = "Please upload image")]
        public string image { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

}
