namespace AutoYa_Backend.AutoYa.Resources.GET;

public class CarReviewResource
{
    public int Id { get; set; }
    public int Score { get; set; }

    public int CarId { get; set; }
    public int TenantId { get; set; }
    public int BodyInformationId { get; set; }
}