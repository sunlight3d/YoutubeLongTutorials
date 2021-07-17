using System;
using MovieApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Repositories
{
    public class InMemoryMovieRepository: IMovieRepository {
        private readonly List<Movie> movies = new() {
            new Movie(){
                Id = Guid.NewGuid(), Name = "Star Wars", ReleaseYear = 1977
            },
            new Movie(){
                Id = Guid.NewGuid(), Name = "Back to the Future", ReleaseYear = 1985
            },
            new Movie(){
                Id = Guid.NewGuid(), Name = "The Matrix", ReleaseYear = 1999
            },
            new Movie(){
                Id = Guid.NewGuid(), Name = "Inception", ReleaseYear = 2010
            },
            new Movie(){
                Id = Guid.NewGuid(), Name = "Interstellar", ReleaseYear = 2010
            },
        };
        
        public async Task<IEnumerable<Movie>> GetMoviesAsync() {
            return await Task.FromResult(movies);
        }
        public async Task<Movie> GetMovieAsync(Guid id) {
            return await Task.FromResult(this.movies.Where(movie => movie.Id == id).SingleOrDefault());
        }
        public async Task InsertMovieAsync(Movie movie) {
            movies.Add(movie);
            await Task.CompletedTask;
        }
        public async Task UpdateMovieAsync(Movie movie) {
             int index = movies.FindIndex(eachMovie => eachMovie.Id == movie.Id);
             movies[index] = movie;
             await Task.CompletedTask;
        }
        public async Task DeleteMovieAsync(Guid id) {
            int index = movies.FindIndex(eachMovie => eachMovie.Id == id);
            movies.RemoveAt(index);
            await Task.CompletedTask;
        }
    }

}