using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.Shared.Domain.Services.Communication;

namespace AutoYa_Backend.AutoYa.Domain.Communication;

public class CarDocumentationResponse : BaseResponse<CarDocumentation>
{
    public CarDocumentationResponse(string message) : base(message)
    {
    }

    public CarDocumentationResponse(CarDocumentation resource) : base(resource)
    {
    }
}