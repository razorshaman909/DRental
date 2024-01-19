using System.Data;
using Dapper;
using System.Text;
using DRental.Models;

namespace DRental.Services
{
    public class MovieService
    {
        private readonly IDbConnection _connection;
        public MovieService(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Movie>> GetMovies()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine("[m].MovieId");
            sb.AppendLine(", [m].Title");
            sb.AppendLine(", [m].ReleaseDate");
            sb.AppendLine(", [m].DirectorId");
            //Genre
            sb.AppendLine(", [g].GenreId");
            sb.AppendLine(", [g].GenreName");
            //MovieGenre
            sb.AppendLine(", [mg].MovieGenreId");
            sb.AppendLine(", [mg].MovieId");
            sb.AppendLine(", [mg].GenreId");
            //Director
            sb.AppendLine(", [d].DirectorId");
            sb.AppendLine(", [d].Name");
            sb.AppendLine("LEFT INNER JOIN MovieGenre AS [mg] ON [mg].MovieId = [m].MovieId");
            sb.AppendLine("LEFT INNER JOIN Genre AS [g] on [g].GenreId = [mg].GenreId");
            sb.AppendLine("LEFT INNER JOIN Director AS [d] on [d].DirectorId = [m].DirectorId");

            string query = sb.ToString();

            return await _connection.QueryAsync<Movie, Genre, MovieGenre, Director, Movie>(
                query,
                (movie, genre, moviegenre, director) =>
                {
                    movie.Genres = (IList<Genre>?)genre;
                    movie.MovieGenres = (IList<MovieGenre>?)moviegenre;
                    movie.Director = director;

                    return movie;
                }
            );
        }
    }
}
