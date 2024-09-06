using api_cinema_challenge.Models;

namespace api_cinema_challenge.Repositories
{
    public interface IMovieRepository
    {
        public Task<List<Movie>> GetMovies();
        public Task<Movie> GetMovieById(int id);
        public Task<Movie> AddMovie(Movie entity);
        public Task<Movie> UpdateMovieById(Movie entity, int id);
        public Task<Movie> DeleteMovieById(int id);
    }
}
