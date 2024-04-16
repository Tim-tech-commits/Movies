using Movies.BLL.Abstract;
using Movies.Core.Models;
using Newtonsoft.Json;

namespace Movies.BLL.Concrete
{
    public class MoviesService : IMoviesService
    {
        private readonly string _filePath;

        public MoviesService(string filePath) => _filePath = filePath;

        public async Task<List<Movie>> GetMovies(string genre = "", string title = "")
        {
            try
            {
                var json = await File.ReadAllTextAsync(_filePath);
                var movieList = JsonConvert.DeserializeObject<MovieList>(json) ?? throw new("Failed to deserialize movie list");
                List<Movie> movies = movieList.Movies;

                if (!string.IsNullOrEmpty(genre))
                    movies = movies.Where(m => m.Genre.Any(g => g.Contains(genre, StringComparison.CurrentCultureIgnoreCase))).ToList();

                if (!string.IsNullOrEmpty(title))
                    movies = movies.Where(m => m.Title.Contains(title, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return movies;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
