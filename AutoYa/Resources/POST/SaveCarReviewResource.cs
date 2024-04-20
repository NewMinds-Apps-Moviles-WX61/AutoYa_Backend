namespace AutoYa_Backend.AutoYa.Resources.POST;

public class SaveCarReviewResource
{
    public int Score { get; set; }

    public int CarId { get; set; }
    public int TenantId { get; set; }
    public string Text { get; set; }
    public string Date { get; set; }
    public string Time { get; set; }
}