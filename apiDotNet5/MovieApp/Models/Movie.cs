using System;

namespace MovieApp.Models
{   
    public record Movie {
        public Guid Id {get; init;}
        public string Name { get; init; }   
        public ushort ReleaseYear {get; init;}

    }
}