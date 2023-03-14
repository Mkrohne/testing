using _01_SqlClient_Dapper.Models;
using _01_SqlClient_Dapper.Models.Entities;


namespace _01_SqlClient_Dapper.Services
{
    internal class CustomerService
    {
        public static async Task SaveAsync(Customer customer)
        {
            var database = new DatabaseService();

            await database.SaveCustomerAsync(new CustomerEntity
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                AddressId = await database.GetOrSaveAddressAsync(new AddressEntity
                {
                    StreetName = customer.StreetName,
                    PostalCode = customer.PostalCode,
                    City = customer.City,
                })
            });
        }

        public static async Task<IEnumerable<Customer>> GetAllAsync()
        {
            var database = new DatabaseService();
            return await database.GetAllCustomersAsync();
        }

        public static async Task<Customer> GetAsync(string email)
        {
            var database = new DatabaseService();
            return await database.GetCustomerAsync(email);
        }
    }
}
