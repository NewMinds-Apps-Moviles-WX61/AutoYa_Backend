using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.Shared.Domain.Services.Communication;

namespace AutoYa_Backend.AutoYa.Domain.Communication;

public class RequestResponse : BaseResponse<Request>
{
    public RequestResponse(string message) : base(message)
    {
    }

    public RequestResponse(Request resource) : base(resource)
    {
    }
}