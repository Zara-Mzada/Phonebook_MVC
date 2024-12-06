namespace WebApplication1.Models;

public class Contact
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }

    public Contact(string name, string surname, string phone, string email, string website)
    {
        this.Name = name;
        this.Surname = surname;
        this.Phone = phone;
        this.Email = email;
        this.Website = website;
    }
}