using System;
using MovieApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp.Repositories
{
    public interface IMovieRepository {
        public IEnumerable<Movie> GetMovies();
        public Movie GetMovie(Guid id);
    }
}