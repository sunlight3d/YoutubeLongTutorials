using System;
using MovieApp.Models;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;
/*
docker login
docker run -d --rm --name mongoMovieApp -p 27018:27017 -v mongoDBDatabase:/data/db mongo
docker volume ls
docker volume rm mongoDBDatabase
docker run -d --rm --name mongoMovieApp -p 27018:27017 -v mongoDBDatabase:/data/db -e MONGO_INITDB_ROOT_USERNAME=admin -e MONGO_INITDB_ROOT_PASSWORD=123456 mongo
*/
namespace MovieApp.Repositories
{
    public class MongoDbMovieRepository : IMovieRepository
    {
        private const string databaseName = "movieDB";
        private const string collectionName = "movies";
        private readonly IMongoCollection<Movie> moviesCollection;
        private readonly FilterDefinitionBuilder<Movie> filterBuilder = Builders<Movie>.Filter;
        public MongoDbMovieRepository(IMongoClient mongoClient)
        {
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(databaseName);
            moviesCollection = mongoDatabase.GetCollection<Movie>(collectionName);
        }
        public async Task InsertMovieAsync(Movie movie)
        {
            await moviesCollection.InsertOneAsync(movie);
        }
        public async Task<Movie> GetMovieAsync(Guid id)
        {
            var filter = filterBuilder.Eq(eachMovie => eachMovie.Id, id);
            return await moviesCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            return await moviesCollection.Find(new BsonDocument()).ToListAsync();
        }
        public async Task DeleteMovieAsync(Guid id)
        {
            var filter = filterBuilder.Eq(existingItem => existingItem.Id, id);            
            await moviesCollection.DeleteOneAsync(filter);
        }
        
        public async Task UpdateMovieAsync(Movie movie)
        {
            var filter = filterBuilder.Eq(existingItem => existingItem.Id, movie.Id);            
            await moviesCollection.ReplaceOneAsync(filter, movie);
        }

    }

}