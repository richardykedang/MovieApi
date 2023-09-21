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

        public string AddMovies(MovieCreateRequest model)
        {
            if (model.img != null)
            {
                string fileName = model.img.FileName;
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), (@"C:\Upload\" + fileName));

                FileInfo file = new FileInfo(filePath);
                if (file.Exists)
                {
                    file.Delete();
                }

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.img.CopyTo(fileStream);
                }
                var tes = filePath;
                Movie movie = new Movie()
                {
                    title = model.title,
                    description = model.description,
                    image = tes,
                    rating = model.rating,
                    created_at = DateTime.Now,
                };

                _context.Movies.Add(movie);
                _context.SaveChanges();
                return "Success";

            }

            return "Gagal";
        }

        public void Delete(Movie movie)
        {
            if (movie.image != null)
            {
                string fileName = movie.image;
                

                FileInfo file = new FileInfo(fileName);
                if (file.Exists)
                {
                    file.Delete();
                }
            }
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

        public void Update(Movie movie, MovieUpdateRequest model)
        {
            if (model.img != null)
            {
                string fileName = model.img.FileName;
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), (@"C:\Upload\" + fileName));

                FileInfo file = new FileInfo(filePath);
                if (file.Exists)
                {
                    file.Delete();
                }

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.img.CopyTo(fileStream);
                }
                var tes = filePath;
                movie.title = model.title;
                movie.description = model.description;
                movie.image = tes;
                movie.rating = model.rating;
                movie.updated_at = DateTime.Now;
                _context.SaveChanges();
            }
            
        }
    }
}
