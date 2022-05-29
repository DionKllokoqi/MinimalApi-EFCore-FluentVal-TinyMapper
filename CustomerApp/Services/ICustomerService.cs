using CustomerApp.Contracts;
using CustomerApp.Domain;

namespace CustomerApp.Services
{
    public interface ICustomerService
    {
         Task<IEnumerable<CustomerDto?>> GetAllAsync();
         Task<CustomerDto?> GetByIdAsync(string Id);
         Task CreateAsync(CustomerDto customerDto);
         Task<bool> DeleteAsync(Guid id);
    }
}