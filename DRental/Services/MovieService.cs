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
            /*StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine("[m].MovieId");
            sb.AppendLine(", [m].Title");
            sb.AppendLine(", [m].ReleaseDate");
            sb.AppendLine(", [m].DirectorId");
            //MovieGenre
            sb.AppendLine(", [mg].MovieGenreId AS Id");
            sb.AppendLine(", [mg].MovieId");
            sb.AppendLine(", [mg].GenreId");
            //Genre
            sb.AppendLine(", [g].GenreId AS Id");
            sb.AppendLine(", [g].GenreName");            
            //Director
            sb.AppendLine(", [d].DirectorId AS Id");
            sb.AppendLine(", [d].Name");

            sb.AppendLine("FROM dbo.[Movie] AS [m]");
            sb.AppendLine("LEFT OUTER JOIN dbo.[MovieGenre] AS [mg] ON [mg].MovieId = [m].MovieId");
            sb.AppendLine("LEFT OUTER JOIN dbo.[Genre] AS [g] ON [g].GenreId = [mg].GenreId");
            sb.AppendLine("LEFT OUTER JOIN dbo.[Director] AS [d] ON [d].DirectorId = [m].DirectorId");

            string query = sb.ToString();
            var movieDict = new Dictionary<int, Movie>();


            return await _connection.QueryAsync<Movie, MovieGenre, Genre, Director, Movie>(
                query,
                (movie, moviegenre, genre, director) =>
                {                    
                    *//*if (moviegenre.MovieId != null)
                    {
                        moviegenre.MovieId = movie.MovieId;
                    }*//*
                    if (movieDict.TryGetValue(movie.MovieId, out Movie existingMovie))
                    {
                        movie = existingMovie;
                    }
                    else
                    {                        
                        movie.Genres = new List<Genre>();
                        movieDict.Add(movie.MovieId, movie);
                    }

                    if (moviegenre.MovieId == movie.MovieId)
                    {
                        movie.Genres.Add(genre);
                    }

                    movie.Director = director;

                    return movie;
                }

            );
            return movieDict.Values.ToList();*/

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine("[m].MovieId");
            sb.AppendLine(", [m].Title");
            sb.AppendLine(", [m].ReleaseDate");
            sb.AppendLine(", [m].DirectorId");

            sb.AppendLine(", (");
            sb.AppendLine("SELECT STRING_AGG([g].GenreName,',') ");
            sb.AppendLine("FROM dbo.[MovieGenre] AS [mg] ");
            sb.AppendLine("JOIN dbo.[Genre] AS [g] ON [g].GenreId = [mg].GenreId ");
            sb.AppendLine("WHERE [mg].MovieId = [m].MovieId ");
            sb.AppendLine(") AS Genres");

            //Director
            sb.AppendLine(", [d].DirectorId AS Id");
            sb.AppendLine(", [d].Name");

            sb.AppendLine("FROM dbo.[Movie] AS [m]");
            sb.AppendLine("LEFT OUTER JOIN dbo.[Director] AS [d] ON [d].DirectorId = [m].DirectorId");

            string query = sb.ToString();

            return await _connection.QueryAsync<Movie, Director, Movie>(
                query,
                (movie, director) =>
                {

                    movie.Director = director;

                    return movie;
                }
                );
        }
    }
}
