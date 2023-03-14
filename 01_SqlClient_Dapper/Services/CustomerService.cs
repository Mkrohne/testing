using _01_SqlClient_Dapper.Models;
using _01_SqlClient_Dapper.Models.Entities;

namespace _01_SqlClient_Dapper.Services
{
    internal class CustomerService
    {
        public async Task SaveAsync(Customer customer)
        {
            var database = new DatabaseService();
            await database.SaveCustomerAsync(new CustomerEntity
            {

            });
        }
    }
}
