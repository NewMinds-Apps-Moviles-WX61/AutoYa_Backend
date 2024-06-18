namespace AutoYa_Backend.AutoYa.Resources.POST;

public class SaveRentResource
{
    public string SubmissionDate { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public string SignedContractURL { get; set; }
    public int TotalPrice { get; set; }

    public int CarId { get; set; }
    public int PropietaryId { get; set; }
    public int TenantId { get; set; }
}