namespace AutoYa_Backend.AutoYa.Domain.Models;

public class CarPhoto
{
    public int Id { get; set; }
    public string CarPhotoURL { get; set; }
    
    public int CarId { get; set; }
    public Car Car { get; set; }
}