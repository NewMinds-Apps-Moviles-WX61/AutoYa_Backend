using AutoYa_Backend.AutoYa.Domain.Models;

namespace AutoYa_Backend.AutoYa.Resources.GET;

public class TenantResource
{
    public int Id { get; set; }
    public string LicenceNumber { get; set; }
    public string CriminalRecordURL { get; set; }

    public int UserId { get; set; }
}