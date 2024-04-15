namespace AutoYa_Backend.AutoYa.Resources.GET;

public class RentResource
{
    public int Id { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public string SignedContractURL { get; set; }
    public string Status { get; set; }

    public int RequestId { get; set; }
}