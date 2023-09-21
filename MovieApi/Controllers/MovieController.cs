using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;
using MovieApi.Models;
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

        //api/movies/1
        [HttpGet("{ID}")]
        public IActionResult GetMovies(int ID)
        {
            var MovieList = _movie.GetMoviesById(ID);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(MovieList);
        }

        //api/movies
        [HttpPost]
        public IActionResult Movies([FromForm] MovieCreateRequest model)
        {

            if (model.title.IsNullOrEmpty() || model.title == "string")
            {
                ModelState.AddModelError("title", "Please enter the title");
                return ValidationProblem(ModelState);
            };
            
            

            var MovieList = _movie.AddMovies(model);

            return Ok(MovieList);
        }

        //api/movies/ID
        [HttpPatch("{ID}")]
        public IActionResult Movies(int ID, [FromForm] MovieUpdateRequest model)
        {
            if(model == null || model.title.IsNullOrEmpty())
            {
                return BadRequest("Movie is null");
            }

            Movie movie = _movie.GetMoviesById(ID);
            if(movie == null)
            {
                return NotFound("Movie Cannot be found");
            }
            
            _movie.Update(movie,model);
            return Ok("Success");

        }


        //api/movies/ID
        [HttpDelete("{ID}")]
        public IActionResult Movies(int ID)
        {
            Movie movie = _movie.GetMoviesById(ID);
            if(movie == null)
            {
                return NotFound("Movie Not Found");
            }

            _movie.Delete(movie);
            return Ok();
        }
    }
}
