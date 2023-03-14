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
            customer.StreetName = Console.ReadLine() ?? "";

            Console.Write("Postnummer: ");
            customer.PostalCode = Console.ReadLine() ?? "";

            Console.Write("Stad: ");
            customer.City = Console.ReadLine() ?? "";

            //save customer to database
            await CustomerService.SaveAsync(customer);
        }

        public async Task ListAllContactsAsync()            
        {
            //get all customers+addresses from database
            var customers = await CustomerService.GetAllAsync();

            if (customers.Any())
            {
                foreach (Customer customer in customers)
                {
                    Console.WriteLine($"Kundnummer: {customer.Id}");
                    Console.WriteLine($"Namn: {customer.FirstName} {customer.LastName}");
                    Console.WriteLine($"E-postadress: {customer.Email}");
                    Console.WriteLine($"Telefonnummer: {customer.PhoneNumber}");
                    Console.WriteLine($"Adress: {customer.StreetName}, {customer.PostalCode}, {customer.City}");
                    Console.WriteLine("");

                }
            }
            else
            {
                Console.WriteLine("Inga kunder finns i databasen.");
                Console.WriteLine("");
            }
        }

        public async Task ListSpecificContactAsync()
        {            
            Console.Write("Ange e-postadress på kunden: ");
            var email = Console.ReadLine();

            if (!string .IsNullOrEmpty(email))
            {
                //get specific customer+address from database  
                var customer = await CustomerService.GetAsync(email);

                if (customer != null)
                {
                    Console.WriteLine($"Kundnummer: {customer.Id}");
                    Console.WriteLine($"Namn: {customer.FirstName} {customer.LastName}");
                    Console.WriteLine($"E-postadress: {customer.Email}");
                    Console.WriteLine($"Telefonnummer: {customer.PhoneNumber}");
                    Console.WriteLine($"Adress: {customer.StreetName}, {customer.PostalCode}, {customer.City}");
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
