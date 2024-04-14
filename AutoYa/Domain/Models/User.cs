namespace AutoYa_Backend.AutoYa.Domain.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public string DNI { get; set; }
    public string PhotoURL { get; set; }
    
    public Propietary Propietary { get; set; }
    public Tenant Tenant { get; set; }
    public IList<Notification> Notifications { get; set; }
}