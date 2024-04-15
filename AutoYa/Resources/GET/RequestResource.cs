using AutoYa_Backend.AutoYa.Domain.Models;

namespace AutoYa_Backend.AutoYa.Resources.GET;

public class RequestResource
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