//using api_cinema_challenge.Migrations;
using api_cinema_challenge.Models;
using api_cinema_challenge.Repositories;
using api_cinema_challenge.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace api_cinema_challenge.EndPoints
{
    public static class TicketEndPoint
    {
        public static void ConfigureTicketEndPoints(this WebApplication app)
        {
            var ticket = app.MapGroup("ticket");
            ticket.MapPost("/", AddSTickets);
            ticket.MapGet("/", GetTickets);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetTickets(ITicketRepository repo)
        {
            Payload<List<Ticket>> response = new Payload<List<Ticket>>();

            response.data = await repo.GetTickets();
            return TypedResults.Ok(response);
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        private static async Task<IResult> AddSTickets(ITicketRepository repo, TicketPostModel model)
        {
            Payload<Ticket> response = new Payload<Ticket>();
            try
            {
                response.data = await repo.AddTicket(new Ticket()
                {
                    numSeats = model.numSeats
                });

                return TypedResults.Ok(response);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

    }
}
