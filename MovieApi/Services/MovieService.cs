using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Models;
using MovieApi.Services.Interface;

namespace MovieApi.Services
{
    public class MovieService : IMovie
    {
        private AppDbContext _context;
        
        public MovieService(AppDbContext context)
        {
            _context = context;
        }

        public string AddMovies(MovieRequest model)
        {
            Movie movie = new Movie()
            {
                title = model.title,
                description = model.description,
                image = model.image,
                rating = model.rating,
                created_at = DateTime.Now,
            };

            _context.Movies.Add(movie);
            _context.SaveChanges();
            return "Success";
           
        }

        public void Delete(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies.ToList();
           
        }

        public Movie GetMoviesById(int id)
        {
            return _context.Movies.FirstOrDefault(x => x.id == id);
        }

        public void Update(Movie movie, MovieRequest model)
        {
            movie.title = model.title;
            movie.description = model.description;
            movie.image = model.image;
            movie.rating = model.rating;
            movie.updated_at = DateTime.Now;
            _context.SaveChanges();
        }
    }
}
