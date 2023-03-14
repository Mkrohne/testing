using _01_SqlClient_Dapper.Services;
var menu = new MenuService();

while (true)
{
    Console.Clear();
    Console.WriteLine("1. Skapa en ny kontakt");
    Console.WriteLine("2. Visa alla kontakter");
    Console.WriteLine("3. Visa en specefik kontakt");
    Console.Write("Välj ett av alternativen (1-3):");


    switch (Console.ReadLine())
    {
        case "1":
            Console.Clear();
            await menu.CreateNewContactAsync();
            break;

        case "2":
            Console.Clear();
            await menu.ListAllContactsAsync();
            break;


        case "3":
            Console.Clear();
            await menu.ListSpecificContactAsync();
            break;

    }
    Console.WriteLine("\nTryck på valfri knapp för att fortsätta");
    Console.ReadKey();
}