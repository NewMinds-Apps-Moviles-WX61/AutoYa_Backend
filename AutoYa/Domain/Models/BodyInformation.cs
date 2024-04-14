namespace AutoYa_Backend.AutoYa.Domain.Models;

public class BodyInformation
{
    public int Id { get; set; }
    public string Text { get; set; }
    public string Date { get; set; }
    public string Time { get; set; }
    
    public CarReview CarReview { get; set; }
    public Message Message { get; set; }
    public Notification Notification { get; set; }
    public Review Review { get; set; }
}