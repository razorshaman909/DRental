using DRental.Models;
using DRental.Services;
using Microsoft.AspNetCore.Mvc;

namespace DRental.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieService _movieService;

        public MoviesController(
            MovieService movieService)
        {
            _movieService = movieService;
        }

        //GET: Movies
        public async Task<IActionResult> Index() 
        {
            IEnumerable<Movie> movies = await _movieService.GetMovies();
            return View(movies);
        }
    }
}
