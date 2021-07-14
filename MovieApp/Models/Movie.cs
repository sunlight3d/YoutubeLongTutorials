using System;
using MovieApp.Dto;
namespace MovieApp.Models
{   
    public record Movie {
        public Guid Id {get; init;}
        public string Name { get; init; }   
        public ushort ReleaseYear {get; init;}
        public MovieDto ToDto() {
            return new MovieDto {
                Id = this.Id,
                Name = this.Name,
                ReleaseYear = this.ReleaseYear
            };
        }

    }
}