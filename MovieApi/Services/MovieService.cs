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
        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies.ToList();
           
        }

        public Movie GetMoviesById(int id)
        {
            return _context.Movies.FirstOrDefault(x => x.id == id);
        }
    }
}
