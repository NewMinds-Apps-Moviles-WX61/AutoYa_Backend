using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.Shared.Domain.Services.Communication;

namespace AutoYa_Backend.AutoYa.Domain.Communication;

public class TenantResponse : BaseResponse<Tenant>
{
    public TenantResponse(string message) : base(message)
    {
    }

    public TenantResponse(Tenant resource) : base(resource)
    {
    }
}