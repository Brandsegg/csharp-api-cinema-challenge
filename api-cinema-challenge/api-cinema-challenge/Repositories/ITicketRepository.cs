using api_cinema_challenge.Models;

namespace api_cinema_challenge.Repositories
{
    public interface ITicketRepository
    {
        Task<Ticket> AddTicket(Ticket entity);
        Task<List<Ticket>> GetTickets();
    }
}
