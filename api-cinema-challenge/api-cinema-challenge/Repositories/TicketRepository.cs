using api_cinema_challenge.Data;
using api_cinema_challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace api_cinema_challenge.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private CinemaContext _db;
        public TicketRepository(CinemaContext db)
        {
            _db = db;
        }

        public async Task<Ticket> AddTicket(Ticket entity)
        {
            await _db.Tickets.AddAsync(entity);
            await _db.SaveChangesAsync();

            return entity;
        }

        public async Task<List<Ticket>> GetTickets()
        {
            return  await _db.Tickets.ToListAsync();
        }

    }
}
