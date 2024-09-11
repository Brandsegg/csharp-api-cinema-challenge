using api_cinema_challenge.Data;
using api_cinema_challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace api_cinema_challenge.Repositories
{
    public class ScreeningRepository : IScreeningRepository
    {

        private CinemaContext _db;
        public ScreeningRepository(CinemaContext db)
        {
            _db = db;
        }

        public async Task<Screening> AddScreening(Screening entity)
        {
            await _db.Screenings.AddAsync(entity);
            
            await _db.SaveChangesAsync();
            var result = _db.Screenings.Include(s => s.movie).FirstOrDefault(m => m.Id == entity.Id);

            return result;
        }

        public async Task<List<Screening>> GetScreenings()
        {
            return await _db.Screenings.ToListAsync();
        }
    }
}
