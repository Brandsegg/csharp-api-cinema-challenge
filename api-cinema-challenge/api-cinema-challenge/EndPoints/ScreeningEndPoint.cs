//using api_cinema_challenge.Migrations;
using api_cinema_challenge.Models;
using api_cinema_challenge.Repositories;
using api_cinema_challenge.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace api_cinema_challenge.EndPoints
{
    public static class ScreeningEndPoint
    {
        public static void ConfigureScreeningEndPoints(this WebApplication app)
        {
            var screening = app.MapGroup("screening");
            screening.MapPost("/", AddScreening);
            screening.MapGet("/", GetScreenings);

        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetScreenings(IScreeningRepository repo)
        {
            Payload<List<Screening>> response = new Payload<List<Screening>>();

            response.data =  await repo.GetScreenings();
            return TypedResults.Ok(response);
        }

       
        [ProducesResponseType(StatusCodes.Status201Created)]
        private static async Task<IResult> AddScreening(IScreeningRepository repo, int id, ScreeningPostModel model)
        {
            Payload<Screening> response = new Payload<Screening>();
            try
            {
                response.data = await repo.AddScreening(new Screening()
                {
                    MovieId = id,
                    ScreenNumber = model.ScreenNumber,
                    Capacity = model.Capacity,
                    StartsAt = model.StartsAt.ToUniversalTime()
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
