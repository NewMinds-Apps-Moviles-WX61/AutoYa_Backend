namespace AutoYa_Backend.AutoYa.Resources.POST;

public class SaveRequestResource
{
    public string Status { get; set; }
    public string SubmissionDate { get; set; }
    public int TotalPrice { get; set; }

    public int CarId { get; set; }
    public int PropietaryId { get; set; }
    public int TenantId { get; set; }
}