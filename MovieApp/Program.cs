using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
/*
dotnet user-secrets init
key saved to MovieApp.csproj
dotnet user-secrets set MongoDBSettings:Password 123456
%APPDATA%\Microsoft\UserSecrets\<user_secrets_id>\secrets.json

docker login
docker-compose -f movieapp-compose.yml up -d
docker run -d --rm --name mongo-movie-app -p 27018:27017 -v mongoDBDatabase:/data/db mongo
docker volume ls
docker volume rm mongoDBDatabase
docker run -d --rm --name mongo-movie-app -p 27018:27017 -v mongoDBDatabase:/data/db -e MONGO_INITDB_ROOT_USERNAME=admin -e MONGO_INITDB_ROOT_PASSWORD=123456 mongo

dotnet add package AspNetCore.HealthChecks.MongoDb
docker stop mongoMovieApp
https://localhost:5001/health
https://localhost:5001/health/ready
Command Pallete => docker:add docker files to workspace
docker build -t movieapp:1.0 .

*/
namespace MovieApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
