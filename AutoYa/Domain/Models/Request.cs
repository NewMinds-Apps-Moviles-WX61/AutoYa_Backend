namespace AutoYa_Backend.AutoYa.Domain.Models;

public class Request
{
    public int Id { get; set; }
    public string Status { get; set; }
    public string SubmissionDate { get; set; }
    public int TotalPrice { get; set; }
    
    public int CarId { get; set; }
    public int PropietaryId { get; set; }
    public int TenantId { get; set; }
    public Rent Rent { get; set; }
}