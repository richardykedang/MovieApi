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
                //string link = "https://bankindonesiagov-my.sharepoint.com/:f:/r/personal/richardy_pn_p_bi_go_id/Documents/tes?csf=1&web=1&e=B9uRYA";
                //string filePath = Path.Combine(@link + fileName);

                FileInfo files = new FileInfo(filePath);
                if (files.Exists)
                {
                    files.Delete();
                }

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.img.CopyTo(fileStream);
                    //File.Copy(fileStream, link);
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

		public List<Movie> GetMoviesByTitle(string title)
		{
            return _context.Movies.Where(oh => oh.title.Contains(title)).ToList();
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
