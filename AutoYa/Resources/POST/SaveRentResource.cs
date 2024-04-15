namespace AutoYa_Backend.AutoYa.Resources.POST;

public class SaveRentResource
{
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public string SignedContractURL { get; set; }
    public string Status { get; set; }

    public int RequestId { get; set; }
}