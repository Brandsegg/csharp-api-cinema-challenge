using api_cinema_challenge.Models;

namespace api_cinema_challenge.Repositories
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetCustomers();
        Task<Customer> GetById(int id);
        Task<Customer> AddCustomer(Customer entity);
        Task<Customer> UpdateCustomerById(int id, Customer entity);
        Task<Customer> DeleteCustomerById(int id);
    }
}
