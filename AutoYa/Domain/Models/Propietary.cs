namespace AutoYa_Backend.AutoYa.Domain.Models;

public class Propietary
{
    public int Id { get; set; }
    public string ContractURL { get; set; }
    
    public int UserId { get; set; }
    public User User { get; set; }
    public IList<Car> Cars { get; set; }
    public IList<Destination> Destinations { get; set; }
    public IList<Request> Requests { get; set; }
}