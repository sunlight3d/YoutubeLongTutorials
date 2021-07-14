using System;
namespace MovieApp.Dto {
    public record MovieDto {
        public Guid Id {get; init;}
        public string Name { get; init; }   
        public ushort ReleaseYear {get; init;}
    }
}