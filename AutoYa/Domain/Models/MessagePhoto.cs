namespace AutoYa_Backend.AutoYa.Domain.Models;

public class MessagePhoto
{
    public int Id { get; set; }
    public string PhotoURL { get; set; }
    
    public int MessageId { get; set; }
    public Message Message { get; set; }
}