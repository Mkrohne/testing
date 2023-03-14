using _01_SqlClient_Dapper.Models;



namespace _01_SqlClient_Dapper.Services
{
    internal class DatabaseService
    {
        private readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\macka\Desktop\Win22\dotnet\SQL\datalagring\Lektion-4\01_SqlClient_Dapper\Data\local_sql_db.mdf;Integrated Security=True;Connect Timeout=30";

        public async Task SaveCustomerAsync(CustomerEntity customerEntity)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.ExecuteAsync("IF NOT EXISTS (SELECT Id FROM Customers WHERE Email = @Email) INSERT INTO Customers VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @AddressId)", customerEntity);
        }

        public async Task<int> GetOrSaveAddressAsync(AddressEntity addressEntity)
        {
            using var conn = new SqlConnection(_connectionString);
            return await conn.ExecuteScalarAsync<int>("IF NOT EXISTS (SELECT Id FROM Customers WHERE Email = @Email) INSERT INTO Customers VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @AddressId", addressEntity);
        }


    }
    
}
