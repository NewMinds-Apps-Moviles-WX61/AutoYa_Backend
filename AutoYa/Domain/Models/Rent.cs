namespace AutoYa_Backend.AutoYa.Domain.Models;

public class Rent
{
    public int Id { get; set; }
    public string Status { get; set; }
    public string SubmissionDate { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public string SignedContractURL { get; set; }
    public int TotalPrice { get; set; }
    
    public int CarId { get; set; }
    public Car Car { get; set; }
    public int PropietaryId { get; set; }
    public Propietary Propietary { get; set; }
    public int TenantId { get; set; }
    public Tenant Tenant { get; set; }
}