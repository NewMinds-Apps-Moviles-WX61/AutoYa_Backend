using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.Shared.Domain.Services.Communication;

namespace AutoYa_Backend.AutoYa.Domain.Services.Communication;

public class MessagePhotoResponse : BaseResponse<MessagePhoto>
{
    public MessagePhotoResponse(string message) : base(message)
    {
    }

    public MessagePhotoResponse(MessagePhoto resource) : base(resource)
    {
    }
}