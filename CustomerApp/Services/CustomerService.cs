using CustomerApp.Contracts;
using CustomerApp.Domain;
using CustomerApp.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Nelibur.ObjectMapper;

namespace CustomerApp.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerDbContext _dbContext;

        public CustomerService(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(CustomerDto customerDto)
        {
            var customer = TinyMapper.Map<Customer>(customerDto);

            await _dbContext.Customers!.AddAsync(customer);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var customer = await _dbContext.Customers!.FirstAsync(c => c.Id == id);

            if (customer is null)
            {
                return false;
            }

            _dbContext.Customers!.Remove(customer);

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<CustomerDto?>> GetAllAsync()
        {
            var customers = await _dbContext.Customers!.ToListAsync();

            var customerDtos = new List<CustomerDto>();

            foreach (var customer in customers)
            {
                customerDtos.Add(TinyMapper.Map<CustomerDto>(customer));
            }

            return customerDtos;
        }

        public async Task<CustomerDto?> GetByIdAsync(string Id)
        {
            var customer = await _dbContext.Customers!.FirstOrDefaultAsync(x => x.Id.ToString() == Id);

            return TinyMapper.Map<CustomerDto>(customer);
        }
    }
}