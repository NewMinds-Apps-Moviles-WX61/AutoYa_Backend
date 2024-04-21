using AutoYa_Backend.AutoYa.Domain.Models;

namespace AutoYa_Backend.AutoYa.Resources.GET;

public class MessageResource
{
    public int Id { get; set; }
    public bool HasPhoto { get; set; }

    public int BodyInformationId { get; set; }
    public int DestinationId { get; set; }
    public IList<MessagePhoto> MessagePhotos { get; set; }
}