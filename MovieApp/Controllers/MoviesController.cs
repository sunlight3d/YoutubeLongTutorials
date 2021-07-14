using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;
using MovieApp.Repositories;
using System;
using System.Linq;
using MovieApp.Dto;

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
        public IEnumerable<MovieDto> getMovies(){
            return repository.GetMovies().Select(movie => movie.ToDto());
        }
        //GET movies/id
        [HttpGet("{id}")]
        public ActionResult<MovieDto> GetMovie(Guid id) {
            var movie = repository.GetMovie(id).ToDto();
            if(movie == null) {
                return NotFound();
            }
            return Ok(movie);
        }
        [HttpPost]
        public ActionResult<MovieDto> InsertMovie(InsertMovieDto insertMovieDto) {
            Movie movie = new() {
                Id = Guid.NewGuid(),
                Name = insertMovieDto.Name,
                ReleaseYear = insertMovieDto.ReleaseYear
            };
            repository.InsertMovie(movie);
            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id}, movie.ToDto());
        }
        //PUT /movies/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateMovie(Guid id, UpdateMovieDto updateMovieDto) {
            Movie existingMovie = repository.GetMovie(id);
            if(existingMovie is null) {
                return NotFound();
            }
            Movie updatedMovie = existingMovie with {
                Name = updateMovieDto.Name,
                ReleaseYear = updateMovieDto.ReleaseYear
            };
            repository.UpdateMovie(updatedMovie);
            return NoContent();//204
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteMovie(Guid id) {
            repository.DeleteMovie(id);
            return NoContent();
        }
    }

}