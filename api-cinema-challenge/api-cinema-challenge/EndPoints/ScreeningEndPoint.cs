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
            var result = await repo.GetScreenings();
            return TypedResults.Ok(result);
        }

       
        [ProducesResponseType(StatusCodes.Status201Created)]
        private static async Task<IResult> AddScreening(IScreeningRepository repo, ScreeningPostModel model)
        {
            try
            {
                var result = await repo.AddScreening(new Screening()
                {
                    MovieId = model.MovieId,
                    ScreenNumber = model.ScreenNumber,
                    Capacity = model.Capacity,
                    StartsAt = model.StartsAt
                });

                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
        
    }
}
