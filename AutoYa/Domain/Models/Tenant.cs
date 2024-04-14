namespace AutoYa_Backend.AutoYa.Domain.Models;

public class Tenant
{
    public int Id { get; set; }
    public string LicenceNumber { get; set; }
    public string CriminalRecordURL { get; set; }
    
    public int UserId { get; set; }
    public User User { get; set; }
    public IList<CarReview> CarReviews { get; set; }
    public IList<Destination> Destinations { get; set; }
    public IList<Request> Requests { get; set; }
}