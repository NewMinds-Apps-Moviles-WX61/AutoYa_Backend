namespace AutoYa_Backend.AutoYa.Domain.Models;

public class Review
{
    public int Id { get; set; }
    public int Score { get; set; }
    
    public int BodyInformationId { get; set; }
    public BodyInformation BodyInformation { get; set; }
    public int DestinationId { get; set; }
    public Destination Destination { get; set; }
}