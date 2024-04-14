using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.Shared.Domain.Services.Communication;

namespace AutoYa_Backend.AutoYa.Domain.Services.Communication;

public class MessageResponse : BaseResponse<Message>
{
    public MessageResponse(string message) : base(message)
    {
    }

    public MessageResponse(Message resource) : base(resource)
    {
    }
}