using System;
using MovieApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace MovieApp.Repositories
{
    public interface IMovieRepository {
        Task<IEnumerable<Movie>> GetMoviesAsync();
        Task<Movie> GetMovieAsync(Guid id);
        Task InsertMovieAsync(Movie movie);
        Task UpdateMovieAsync(Movie movie);
        Task DeleteMovieAsync(Guid id);
    }
}