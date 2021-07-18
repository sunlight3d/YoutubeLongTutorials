using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MovieApp.Models;
using MovieApp.Repositories;
using MovieApp.Settings;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Serializers;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace MovieApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {                        
            BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
            BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));
            MongoDBSettings mongoDBSettings = Configuration.GetSection("MongoDBSettings").Get<MongoDBSettings>();
            services.AddSingleton<IMongoClient>(ServiceProvider => {                
                return new MongoClient(mongoDBSettings.ConnectionString);                
            });
            //services.AddSingleton<IMovieRepository, InMemoryMovieRepository>();
            services.AddSingleton<IMovieRepository, MongoDbMovieRepository>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MovieApp", Version = "v1" });
            });
            services.AddHealthChecks()
                .AddMongoDb(
                    mongoDBSettings.ConnectionString, 
                    name:"mongodb", 
                    timeout: TimeSpan.FromSeconds(3),
                    tags: new [] {"ready"}
                    );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MovieApp v1"));
                app.UseHttpsRedirection();
            }            

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapHealthChecks("/health");
                endpoints.MapHealthChecks("/health/ready", new HealthCheckOptions{
                    Predicate = (check) => check.Tags.Contains("ready"),
                    ResponseWriter = async(context, report) => {
                        context.Response.ContentType = MediaTypeNames.Application.Json;
                        await context.Response.WriteAsync(JsonSerializer.Serialize(
                            new {
                                status = report.Status.ToString(),
                                //result = report.Entries
                                result = report.Entries.Select(entry => new {
                                    name = entry.Key,
                                    status = entry.Value.Status.ToString(),
                                    exception = entry.Value.Exception?.ToString(),
                                    duration = entry.Value.Duration.ToString()
                                })
                            }
                        ));        
                    }
                });
            });
        }
    }
}
