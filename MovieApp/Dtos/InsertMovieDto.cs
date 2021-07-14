using System;
namespace MovieApp.Dto {
    public record InsertMovieDto {        
        public string Name { get; init; }   
        public ushort ReleaseYear {get; init;}
    }
}