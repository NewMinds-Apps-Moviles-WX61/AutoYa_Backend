namespace AutoYa_Backend.AutoYa.Domain.Models;

public class CarPhoto
{
    public int Id { get; set; }
    public string photoURL { get; set; }
    
    public int CarId { get; set; }
}