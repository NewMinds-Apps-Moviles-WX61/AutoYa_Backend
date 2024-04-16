namespace AutoYa_Backend.AutoYa.Resources.GET;

public class ReviewResource
{
    public int Id { get; set; }
    public int Score { get; set; }

    public int BodyInformationId { get; set; }
    public int DestinationId { get; set; }
}