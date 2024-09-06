using api_cinema_challenge.Models;

namespace api_cinema_challenge.Repositories
{
    public interface IScreeningRepository
    {
        public Task<Screening> AddScreening(Screening entity);
        public Task<List<Screening>> GetScreenings();
    }
}
