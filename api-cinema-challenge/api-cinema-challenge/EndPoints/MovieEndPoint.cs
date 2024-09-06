using api_cinema_challenge.Models;
using api_cinema_challenge.Repositories;
using api_cinema_challenge.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace api_cinema_challenge.EndPoints
{
    public static class MovieEndPoint
    {
        public static void ConfigureMovieEndPoints(this WebApplication app)
        {
            var movies = app.MapGroup("movies");
            movies.MapPost("/", AddMovie);
            movies.MapGet("/", GetMovies);
            //movies.MapGet("/{Id}", GetACustomer);
            movies.MapPut("/{id}", UpdateMovie);
            movies.MapDelete("/", DeleteMovie);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetAMovie(IMovieRepository repo, int id)
        {
            var movie = await repo.GetMovieById(id);

            //return custom object
            return TypedResults.Ok(new {
                title = movie.title, 
                rating = movie.rating,
                description = movie.description,
                runtimeMins = movie.runtimeMins
            });
        }

        private static async Task<IResult> GetMovies(IMovieRepository repo)
        {
            //change to avoid cyclical reference
            //custom object here somewhere
            var result = await repo.GetMovies();
            return TypedResults.Ok(result);
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        private static async Task<IResult> AddMovie(IMovieRepository repo, MoviePostModel model)
        {
            try
            {
                var result = await repo.AddMovie(new Movie() { 
                    title = model.title,
                    rating = model.rating,
                    description = model.description,
                    runtimeMins = model.runtimeMins
                });

                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        private static async Task<IResult> UpdateMovie(IMovieRepository repo, int id, MoviePutModel model)
        {
            try
            {
                var target = await repo.GetMovieById(id);

                target.title = string.IsNullOrEmpty(model.title) ? target.title : model.title;
                target.rating = string.IsNullOrEmpty(model.rating) ? target.rating : model.rating;
                target.description = string.IsNullOrEmpty(model.description) ? target.description : model.description;
                target.runtimeMins = model.runtimeMins <= 0 ? target.runtimeMins : model.runtimeMins;

                await repo.UpdateMovieById(target, id);
                return TypedResults.Ok(target);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> DeleteMovie(IMovieRepository repo, int id)
        {
            var deletedMovie = await repo.DeleteMovieById(id);

            return TypedResults.Ok(deletedMovie);
        }
    }
}
