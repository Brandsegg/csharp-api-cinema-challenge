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
            return entity;
        }

        public async Task<List<Screening>> GetScreenings()
        {
            return await _db.Screenings.ToListAsync();
        }
    }
}
