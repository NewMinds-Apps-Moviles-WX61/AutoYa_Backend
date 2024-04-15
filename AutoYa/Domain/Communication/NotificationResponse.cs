using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.Shared.Domain.Services.Communication;

namespace AutoYa_Backend.AutoYa.Domain.Communication;

public class NotificationResponse : BaseResponse<Notification>
{
    public NotificationResponse(string message) : base(message)
    {
    }

    public NotificationResponse(Notification resource) : base(resource)
    {
    }
}