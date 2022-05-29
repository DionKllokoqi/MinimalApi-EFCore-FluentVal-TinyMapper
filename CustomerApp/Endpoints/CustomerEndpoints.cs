using CustomerApp.Contracts;
using CustomerApp.Services;

namespace CustomerApp.Endpoints
{
    public static class CustomerEndpoints
    {
        public static void ConfigureApi(this WebApplication app)
        {
            app.MapGet("customers", GetAllCustomers);
            app.MapGet("customers/{id:guid}", GetCustomerById);
            app.MapPost("customers", CreateCustomer);
            app.MapDelete("customers/{id:guid}", DeleteCustomer);
        }

        public static async Task<IResult> GetAllCustomers(ICustomerService customerService)
        {
            var customers = await customerService.GetAllAsync();

            return Results.Ok(customers);
        }

        public static async Task<IResult> GetCustomerById(Guid id,
            ICustomerService customerService)
        {
            var customer = await customerService.GetByIdAsync(id.ToString());

            if (customer is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(customer);
        }

        public static async Task<IResult> CreateCustomer(CustomerDto customerDto,
            ICustomerService customerService)
        {
            await customerService.CreateAsync(customerDto);
            
            return Results.Created($"/customers/{customerDto.Id}", customerDto);
        }

        public static async Task<IResult> DeleteCustomer(Guid id,
            ICustomerService customerService)
        {
            var result = await customerService.DeleteAsync(id);

            if (!result)
            {
                return Results.NotFound();
            }

            return Results.Ok();
        }
    }
}