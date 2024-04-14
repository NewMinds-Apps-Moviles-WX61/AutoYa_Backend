using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.Shared.Domain.Services.Communication;

namespace AutoYa_Backend.AutoYa.Domain.Services.Communication;

public class PropietaryResponse : BaseResponse<Propietary>
{
    public PropietaryResponse(string message) : base(message)
    {
    }

    public PropietaryResponse(Propietary resource) : base(resource)
    {
    }
}