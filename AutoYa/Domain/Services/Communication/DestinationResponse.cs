using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.Shared.Domain.Services.Communication;

namespace AutoYa_Backend.AutoYa.Domain.Services.Communication;

public class DestinationResponse : BaseResponse<Destination>
{
    public DestinationResponse(string message) : base(message)
    {
    }

    public DestinationResponse(Destination resource) : base(resource)
    {
    }
}