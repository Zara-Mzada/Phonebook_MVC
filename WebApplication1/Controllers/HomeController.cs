using System.Data.SqlClient;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class HomeController : Controller
{
    private string connectionString =
        "Data Source=mybestserver.database.windows.net;Database=PhoneBook;Integrated Security=false;User ID=dbadmin;Password=CodeWithZahra123;";

    public List<Contact> contacts;
    
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        contacts = new List<Contact>();
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy() 
    {
        return View();
    }

    public IActionResult Info()
    {
        List<Contact> contacts = FetchData();
        return View(contacts);
    }

    public List<Contact> FetchData()
    {
        string query = "SELECT * FROM Contacts";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = Convert.ToString(reader["Name"]);
                            string surname = Convert.ToString(reader["Surname"]);
                            string phone = Convert.ToString(reader["Phone"]);
                            string email = Convert.ToString(reader["Email"]);
                            string website = Convert.ToString(reader["Website"]);

                            Contact contact = new Contact(name, surname, phone, email, website);
                            contacts.Add(contact);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        return contacts;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}