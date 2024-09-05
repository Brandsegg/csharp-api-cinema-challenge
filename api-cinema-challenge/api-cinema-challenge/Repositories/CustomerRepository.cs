using api_cinema_challenge.Models;
using api_cinema_challenge.Data;
using Microsoft.EntityFrameworkCore;


namespace api_cinema_challenge.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private CinemaContext _db;

        public CustomerRepository(CinemaContext db)
        {
            _db = db;
        }

        public async Task<Customer> AddCustomer(Customer entity)
        {
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<Customer> DeleteById(int id)
        {
            var customer = await GetById(id);
            _db.Customers.Remove(customer);
            await _db.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> GetById(int id)
        {
            var entity = await _db.Customers.FirstOrDefaultAsync(c => c.id == id);
            return entity;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            return await _db.Customers.ToListAsync();
        }

        public async Task<Customer> UpdateById(int id, Customer entity)
        {

            _db.Attach(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}
