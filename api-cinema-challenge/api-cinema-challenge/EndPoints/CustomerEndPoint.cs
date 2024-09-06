using api_cinema_challenge.Models;
using api_cinema_challenge.Repositories;
using api_cinema_challenge.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace api_cinema_challenge.EndPoints
{
    public static class CustomerEndPoint
    {
        public static void ConfigureCustomerEndPoints(this WebApplication app) 
        {
            var customers = app.MapGroup("customers");
            customers.MapPost("/", AddCustomer);
            customers.MapGet("/", GetCustomers);
            //customers.MapGet("/{Id}", GetACustomer);
            customers.MapPut("/{id}", UpdateCustomer);
            customers.MapDelete("/", DeleteCustomer);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetACustomer(ICustomerRepository repo, int id)
        {
            var customer = await repo.GetById(id);
            //return custom object
            return TypedResults.Ok(new {name = customer.name, email = customer.email});
        }

        private static async Task<IResult> GetCustomers(ICustomerRepository repo)
        {
            //change to avoid cyclical reference
            //custom object here somewhere
            var result = await repo.GetCustomers();
            List<Object> items  = new List<Object>(); //dont use entity

            //anon  list - DTO 
            foreach (var customer in result)
            {
                items.Add(new{ name = customer.name, email = customer.email, phone = customer.phone });
            }

            return TypedResults.Ok(items);
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        private static async Task<IResult> AddCustomer(ICustomerRepository repo, CustomerPostModel model)
        {
            try
            {
                var result = await repo.AddCustomer(new Customer() {name = model.name, email = model.email, phone = model.phone });
                return TypedResults.Ok(result);
            }
            catch (Exception ex) 
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        private static async Task<IResult> UpdateCustomer(ICustomerRepository repo,int id, CustomerPutModel model)
        {
            try
            {             
                var target = await repo.GetById(id);
                
                target.name = string.IsNullOrEmpty(model.name) ? target.name : model.name;
                target.email = string.IsNullOrEmpty(model.email) ? target.email : model.email;
                target.phone = string.IsNullOrEmpty(model.phone) ? target.phone : model.phone;
                
                await repo.UpdateCustomerById(id, target);
                return TypedResults.Ok(new { name = target.name, email = target.email, phone = target.phone });
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> DeleteCustomer(ICustomerRepository repo, int id)
        {
            var deletedStduent = await repo.DeleteCustomerById(id);

            return TypedResults.Ok(deletedStduent);
        }

    }
}
