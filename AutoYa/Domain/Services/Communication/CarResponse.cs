using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.Shared.Domain.Services.Communication;

namespace AutoYa_Backend.AutoYa.Domain.Services.Communication;

public class CarResponse : BaseResponse<Car>
{
    public CarResponse(string message) : base(message)
    {
    }

    public CarResponse(Car resource) : base(resource)
    {
    }
}