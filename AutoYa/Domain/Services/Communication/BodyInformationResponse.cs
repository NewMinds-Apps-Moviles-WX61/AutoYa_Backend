using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.Shared.Domain.Services.Communication;

namespace AutoYa_Backend.AutoYa.Domain.Services.Communication;

public class BodyInformationResponse : BaseResponse<BodyInformation>
{
    public BodyInformationResponse(string message) : base(message)
    {
    }

    public BodyInformationResponse(BodyInformation resource) : base(resource)
    {
    }
}