namespace AutoYa_Backend.AutoYa.Resources.POST;

public class SaveCarReviewResource
{
    public int Score { get; set; }

    public int CarId { get; set; }
    public int TenantId { get; set; }
    public int BodyInformationId { get; set; }
}