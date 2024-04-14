namespace AutoYa_Backend.AutoYa.Domain.Models;

public class Notification
{
    public int Id { get; set; }
    
    public int BodyInformationId { get; set; }
    public BodyInformation BodyInformation { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}