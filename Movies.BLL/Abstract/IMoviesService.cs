using Movies.Core.Models;

namespace Movies.BLL.Abstract
{
    public interface IMoviesService
    {
        Task<List<Movie>> GetMovies(string genre = "", string title ="");
    }
}
