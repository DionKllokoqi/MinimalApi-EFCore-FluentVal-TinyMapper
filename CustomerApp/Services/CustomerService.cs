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
        }

        public void DeleteAsync(CustomerDto customerDto)
        {
            var customer = TinyMapper.Map<Customer>(customerDto);
            _dbContext.Customers!.Remove(customer);
        }

        public async Task<IEnumerable<CustomerDto?>> GetAllAsync()
        {
            var customers = await _dbContext.Customers!.ToListAsync();
            return TinyMapper.Map<IEnumerable<CustomerDto>>(customers);
        }

        public async Task<CustomerDto?> GetByIdAsync(string Id)
        {
            var customer = await _dbContext.Customers!.FirstOrDefaultAsync(x => x.Id.ToString() == Id);
            return TinyMapper.Map<CustomerDto>(customer);
        }
    }
}