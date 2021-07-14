using System;
using MovieApp.Models;
using System.Collections.Generic;
using System.Linq;

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
        
        public IEnumerable<Movie> GetMovies() {
            return movies;
        }
        public Movie GetMovie(Guid id) {
            return this.movies.Where(movie => movie.Id == id).SingleOrDefault();
        }

    }

}