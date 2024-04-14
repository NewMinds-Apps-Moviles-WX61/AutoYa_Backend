using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.Shared.Domain.Services.Communication;

namespace AutoYa_Backend.AutoYa.Domain.Services.Communication;

public class CarReviewResponse : BaseResponse<CarReview>
{
    public CarReviewResponse(string message) : base(message)
    {
    }

    public CarReviewResponse(CarReview resource) : base(resource)
    {
    }
}