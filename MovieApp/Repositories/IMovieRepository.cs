using System;
using MovieApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp.Repositories
{
    public interface IMovieRepository {
        IEnumerable<Movie> GetMovies();
        Movie GetMovie(Guid id);
        void InsertMovie(Movie movie);
        void UpdateMovie(Movie movie);
    }
}