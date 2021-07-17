using System;
using MovieApp.Models;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Bson;
/*
docker login
docker run -d --rm --name mongoMovieApp -p 27018:27017 -v mongoDBDatabase:/data/db mongo
*/
namespace MovieApp.Repositories
{
    public class MongoDbMovieRepository : IMovieRepository
    {
        private const string databaseName = "movieDB";
        private const string collectionName = "movies";
        private readonly IMongoCollection<Movie> moviesCollection;
        private readonly FilterDefinitionBuilder<Movie> filterBuilder 
        public MongoDbMovieRepository(IMongoClient mongoClient)
        {
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(databaseName);
            moviesCollection = mongoDatabase.GetCollection<Movie>(collectionName);
        }
        public void InsertMovie(Movie movie)
        {
            moviesCollection.InsertOne(movie);
        }
        public Movie GetMovie(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetMovies()
        {
            return moviesCollection.Find(new BsonDocument()).ToList();
        }
        public void DeleteMovie(Guid id)
        {
            throw new NotImplementedException();
        }
        
        

        public void UpdateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }
    }

}