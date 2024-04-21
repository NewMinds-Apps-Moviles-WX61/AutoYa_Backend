using AutoYa_Backend.AutoYa.Domain.Models;

namespace AutoYa_Backend.AutoYa.Resources.GET;

public class BodyInformationResource
{
    public int Id { get; set; }
    public string Text { get; set; }
    public string Date { get; set; }
    public string Time { get; set; }
}