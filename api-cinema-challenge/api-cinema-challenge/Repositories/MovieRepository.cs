using api_cinema_challenge.Data;
using api_cinema_challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace api_cinema_challenge.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private CinemaContext _db;
        public MovieRepository(CinemaContext db)
        { 
            _db = db;
        }

        public async Task<Movie> AddMovie(Movie entity)
        {
            await _db.Movies.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<Movie> DeleteMovieById(int id)
        {
            var movie = await GetMovieById(id);
            _db.Movies.Remove(movie);
            await _db.SaveChangesAsync();
            return movie;
        }

        public async Task<Movie> GetMovieById(int id)
        {
            var entity = await _db.Movies.FirstOrDefaultAsync(m => m.id == id);
            return entity;
        }

        public async Task<List<Movie>> GetMovies()
        {
            return await _db.Movies.ToListAsync();
        }

        public async Task<Movie> UpdateMovieById(Movie entity, int id)
        {
            _db.Attach(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}
