using AutoYa_Backend.AutoYa.Domain.Models;

namespace AutoYa_Backend.AutoYa.Resources.GET;

public class PropietaryResource
{
    public int Id { get; set; }
    public string ContractURL { get; set; }

    public int UserId { get; set; }
}