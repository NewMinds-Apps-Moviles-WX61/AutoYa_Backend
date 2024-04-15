using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.Shared.Domain.Services.Communication;

namespace AutoYa_Backend.AutoYa.Domain.Communication;

public class RentResponse : BaseResponse<Rent>
{
    public RentResponse(string message) : base(message)
    {
    }

    public RentResponse(Rent resource) : base(resource)
    {
    }
}