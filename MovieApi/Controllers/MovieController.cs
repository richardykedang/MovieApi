using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Services.Interface;

namespace MovieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly IMovie _movie;

        public MovieController(IMovie movie)
        {
            _movie = movie;
        }
        //api/movies
        [HttpGet]
        public IActionResult GetMovies()
        {
            var MovieList = _movie.GetMovies();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(MovieList);
        }
    }
}
