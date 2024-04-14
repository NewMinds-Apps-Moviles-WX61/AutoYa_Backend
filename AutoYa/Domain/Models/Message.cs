namespace AutoYa_Backend.AutoYa.Domain.Models;

public class Message
{
    public int Id { get; set; }
    
    public int BodyInformationId { get; set; }
    public int DestinationId { get; set; }
    public IList<MessagePhoto> MessagePhotos { get; set; }
}