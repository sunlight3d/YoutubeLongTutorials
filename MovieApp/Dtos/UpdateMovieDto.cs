using System;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Dto {
    public record UpdateMovieDto {    
        [Required]    
        public string Name { get; init; }   
        [Required]
        [Range(1800, 2022)]
        //validation errors: 400
        public ushort ReleaseYear {get; init;}
    }
}