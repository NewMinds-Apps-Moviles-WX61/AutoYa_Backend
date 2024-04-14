using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.Shared.Domain.Services.Communication;

namespace AutoYa_Backend.AutoYa.Domain.Services.Communication;

public class ReviewResponse : BaseResponse<Review>
{
    public ReviewResponse(string message) : base(message)
    {
    }

    public ReviewResponse(Review resource) : base(resource)
    {
    }
}