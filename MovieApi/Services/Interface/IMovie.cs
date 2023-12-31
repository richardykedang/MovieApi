﻿using Microsoft.AspNetCore.Mvc;
using MovieApi.Models;

namespace MovieApi.Services.Interface
{
    public interface IMovie
    {
        IEnumerable<Movie> GetMovies();
        Movie GetMoviesById(int id);
        List<Movie> GetMoviesByTitle(string title);
        string AddMovies(MovieCreateRequest model);
        void Update(Movie movie, MovieUpdateRequest model);
        void Delete(Movie movie);
    }
}
