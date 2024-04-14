namespace AutoYa_Backend.AutoYa.Domain.Models;

public class Rent
{
    public int Id { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public string SignedContractURL { get; set; }
    public string Status { get; set; }
    
    public int RequestId { get; set; }
    public Request Request { get; set; }
}