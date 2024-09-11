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
            customers.MapDelete("/{id}", DeleteCustomer);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> GetACustomer(ICustomerRepository repo, int id)
        {
            Payload<Customer> response = new Payload<Customer>();

            response.data = await repo.GetById(id);
            //return custom object
            return TypedResults.Ok(response);
        }


        //fix this one
        private static async Task<IResult> GetCustomers(ICustomerRepository repo)
        {
            Payload<List<Customer>> response = new Payload<List<Customer>>();

            var result = await repo.GetCustomers();
            List<Object> items  = new List<Object>();

            //change to payload stuff
            foreach (var customer in result)
            {
                items.Add(new{
                    id = customer.id,
                    name = customer.name, 
                    email = customer.email, 
                    phone = customer.phone,
                    CreatedAt = customer.CreatedAt, 
                    UpdatedAt  = customer.UpdatedAt 
                });
            }

            return TypedResults.Ok(items);
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        private static async Task<IResult> AddCustomer(ICustomerRepository repo, CustomerPostModel model)
        {
            try
            {
                Payload<Customer> response = new Payload<Customer>();
                response.data = await repo.AddCustomer(new Customer() { name = model.name, email = model.email, phone = model.phone });

                return TypedResults.Ok(response);
            }
            catch (Exception ex) 
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        private static async Task<IResult> UpdateCustomer(ICustomerRepository repo,int id, CustomerPutModel model)
        {
            Payload<Customer> response = new Payload<Customer>();

            try
            {             
                var target = await repo.GetById(id);
                
                target.name = string.IsNullOrEmpty(model.name) ? target.name : model.name;
                target.email = string.IsNullOrEmpty(model.email) ? target.email : model.email;
                target.phone = string.IsNullOrEmpty(model.phone) ? target.phone : model.phone;
                //add updated and such here

                response.data = await repo.UpdateCustomerById(id, target);

                return TypedResults.Ok(response);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        private static async Task<IResult> DeleteCustomer(ICustomerRepository repo, int id)
        {
            Payload<Customer> response = new Payload<Customer>();
            response.data = await repo.DeleteCustomerById(id);

            return TypedResults.Ok(response);
        }

    }
}
