using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.Shared.Domain.Services.Communication;

namespace AutoYa_Backend.AutoYa.Domain.Services.Communication;

public class CarPhotoResponse : BaseResponse<CarPhoto>
{
    public CarPhotoResponse(string message) : base(message)
    {
    }

    public CarPhotoResponse(CarPhoto resource) : base(resource)
    {
    }
}