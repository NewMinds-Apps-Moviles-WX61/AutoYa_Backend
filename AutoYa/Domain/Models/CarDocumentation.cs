namespace AutoYa_Backend.AutoYa.Domain.Models;

public class CarDocumentation
{
    public int Id { get; set; }
    public string CarDocumentationPhotoURL { get; set; }
    
    public int CarId { get; set; }
    public Car Car { get; set; }
}