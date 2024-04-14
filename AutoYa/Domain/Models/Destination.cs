namespace AutoYa_Backend.AutoYa.Domain.Models;

public class Destination
{
    public int Id { get; set; }
    public string Issuer { get; set; }
    
    public int PropietaryId { get; set; }
    public int TenantId { get; set; }
    public Message Message { get; set; }
    public Review Reviews { get; set; }
}