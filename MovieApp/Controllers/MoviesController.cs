using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;
using MovieApp.Repositories;
using System;
using System.Linq;
using MovieApp.Dto;
using System.Threading.Tasks;

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
        public async Task<IEnumerable<MovieDto>>  getMoviesAsync(){
            IEnumerable<MovieDto> movieDtos = (await repository.GetMoviesAsync())
                                        .Select(movie => movie.ToDto());
            return movieDtos;
        }
        //GET movies/id
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDto>> GetMovie(Guid id) {
            var movie = (await repository.GetMovieAsync(id))?.ToDto();
            if(movie == null) {
                return NotFound();
            }
            return Ok(movie);
        }
        [HttpPost]
        public async Task<ActionResult<MovieDto>> InsertMovieAsync(InsertMovieDto insertMovieDto) {
            Movie movie = new() {
                Id = Guid.NewGuid(),
                Name = insertMovieDto.Name,
                ReleaseYear = insertMovieDto.ReleaseYear
            };
            await repository.InsertMovieAsync(movie);
            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id}, movie.ToDto());
        }
        //PUT /movies/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMovieAsync(Guid id, UpdateMovieDto updateMovieDto) {
            Movie existingMovie = await repository.GetMovieAsync(id);
            if(existingMovie is null) {
                return NotFound();
            }
            Movie updatedMovie = existingMovie with {
                Name = updateMovieDto.Name,
                ReleaseYear = updateMovieDto.ReleaseYear
            };
            await repository.UpdateMovieAsync(updatedMovie);
            return NoContent();//204
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMovieAsync(Guid id) {
            await repository.DeleteMovieAsync(id);
            return NoContent();
        }
    }

}