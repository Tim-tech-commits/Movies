namespace Movies.Core.Models
{
    public class MovieList
    {
        public List<Movie> Movies { get; set; }

        public MovieList() => Movies = new();
    }
}
