using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Routing.Constraints;

namespace DRental.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        [Required]
        public string? Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public IList<Genre>? Genres { get; set; }
        public IList<MovieGenre>? MovieGenres { get; set; }

        public int? DirectorId { get; set; }
        public Director? Director { get; set; }

        public IList<Item>? Items { get; set; }
    }

    public class Genre
    {
        public int GenreId { get; set; }

        public string? GenreName { get; set; }

        public IList<Movie>? Movies { get; set; }
        public IList<MovieGenre>? MovieGenres { get; set; }
    }

    public class MovieGenre
    {
        public int MovieGenreId { get; set; }
        public int? MovieId { get; set; }
        public int? GenreId { get; set; }
        public Movie? Movies { get; set; }
        public Genre? Genres { get; set; }
    }

    public class Director
    {
        public int DirectorId { get; set; }

        public string? Name { get; set; }

        public IList<Movie>? Movies { get; set; }
    }


}
