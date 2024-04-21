namespace AutoYa_Backend.AutoYa.Resources.POST;

public class SaveDestinationResource
{
    public string Issuer { get; set; }
    public string Category { get; set; }

    public int PropietaryId { get; set; }
    public int TenantId { get; set; }
}