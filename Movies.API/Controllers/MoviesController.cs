using Microsoft.AspNetCore.Mvc;
using Movies.BLL.Abstract;
using Movies.Core.Models;

namespace Movies.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesService _moviesService;
        private readonly ILogger<Movie> _logger;

        public MoviesController(IMoviesService moviesService, ILogger<Movie> logger)
        {
            _moviesService = moviesService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies([FromQuery] string genre = "", [FromQuery] string title = "")
        {
            try
            {
                var movieList = await _moviesService.GetMovies(genre, title);
                return Ok(movieList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex.Message);
            }
        }
    }
}
