using AutoYa_Backend.AutoYa.Domain.Models;

namespace AutoYa_Backend.AutoYa.Resources.GET;

public class DestinationResource
{
    public int Id { get; set; }
    public string Issuer { get; set; }
    public string Category { get; set; }

    public int PropietaryId { get; set; }
    public int TenantId { get; set; }
    public Message Message { get; set; }
    public Review Review { get; set; }
}