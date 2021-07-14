using System;
using MovieApp.Models;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;

namespace MovieApp.Repositories
{
    public class MongoDbMovieRepository : IMovieRepository
    {
        private readonly IMongoCollection<Movie> moviesCollection;
        public MongoDbMovieRepository(IMongoClient mongoClient)
        {
            
        }
        public void DeleteMovie(Guid id)
        {
            throw new NotImplementedException();
        }

        public Movie GetMovie(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetMovies()
        {
            throw new NotImplementedException();
        }

        public void InsertMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public void UpdateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }
    }

}