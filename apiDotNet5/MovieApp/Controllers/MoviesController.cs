using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;
using MovieApp.Repositories;
using System;

namespace MovieApp.Controllers
{
    [ApiController]
    [Route("movies")]
    public class MoviesController: ControllerBase
    {
        //private readonly InMemoryMovieRepository inMemoryMovieRepository;
        //Dependency Injection
        private readonly IMovieRepository repository;
        public MoviesController(IMovieRepository repository)
        {
            //inMemoryMovieRepository = new InMemoryMovieRepository();
            this.repository = repository;
        }
        [HttpGet]
        public IEnumerable<Movie> getMovies(){
            return repository.GetMovies();
        }
        //GET movies/id
        [HttpGet("{id}")]
        public ActionResult<Movie> GetMovie(Guid id) {
            var movie = repository.GetMovie(id);
            if(movie == null) {
                return NotFound();
            }
            return Ok(movie);
        }
    }

}