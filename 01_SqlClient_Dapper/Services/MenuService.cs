using _01_SqlClient_Dapper.Models;

namespace _01_SqlClient_Dapper.Services
{
    internal class MenuService
    {
        public async Task CreateNewContactAsync()
        {
            var customer = new Customer();

            Console.Write("Förnamn: ");
            customer.FirstName = Console.ReadLine() ?? "";

            Console.Write("Efternamn: ");
            customer.LastName = Console.ReadLine() ?? "";

            Console.Write("E-postadress: ");
            customer.Email = Console.ReadLine() ?? "";

            Console.Write("Telefonnummer: ");
            customer.PhoneNumber = Console.ReadLine() ?? "";

            Console.Write("Gatuadress: ");
            customer.Address.StreetName = Console.ReadLine() ?? "";

            Console.Write("Postnummer: ");
            customer.Address.PostalCode = Console.ReadLine() ?? "";

            Console.Write("Stad: ");
            customer.Address.City = Console.ReadLine() ?? "";

            //save customer to database
            var customerService = new CustomerService();
            await customerService.SaveAsync(customer);
        }

        public void ListAllContacts()            
        {
            //get all customers+addresses from database
            var database = new DatabaseService();
            var customers = database.GetCustomers();
            
            if(customers.Any())
            {
                foreach (Customer customer in customers)
                {
                    Console.WriteLine($"Kundnummer: {customer.Id}");
                    Console.WriteLine($"Namn: {customer.FirstName} {customer.LastName}");
                    Console.WriteLine($"E-postadress: {customer.Email}");
                    Console.WriteLine($"Telefonnummer: {customer.PhoneNumber}");
                    Console.WriteLine($"Adress: {customer.Address.StreetName}, {customer.Address.PostalCode}, {customer.Address.City}");
                    Console.WriteLine("");

                }
            }
            else
            {
                Console.WriteLine("Inga kunder finns i databasen.");
                Console.WriteLine("");
            }
        }

        public void ListSpecificContact()
        {
            //get specific customer+address from database
            var database = new DatabaseService();

            Console.Write("Ange e-postadress på kunden: ");
            var email = Console.ReadLine();

            if (!string .IsNullOrEmpty(email))
            {
                var customer = database.GetCustomer(email);

                if (customer != null)
                {
                    Console.WriteLine($"Kundnummer: {customer.Id}");
                    Console.WriteLine($"Namn: {customer.FirstName} {customer.LastName}");
                    Console.WriteLine($"E-postadress: {customer.Email}");
                    Console.WriteLine($"Telefonnummer: {customer.PhoneNumber}");
                    Console.WriteLine($"Adress: {customer.Address.StreetName}, {customer.Address.PostalCode}, {customer.Address.City}");
                    Console.WriteLine("");
                }
                else
                {
                    Console.Clear();
                    Console.Write($"Ingen kund med denna e-postadress {email} hittades");
                    Console.WriteLine("");
                }
            } else
            {
                Console.Clear();
                Console.Write($"Ingen e-postadress angiven");
                Console.WriteLine("");
            }

        }

    }
}
