using AutoMapper;
using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Resources.GET;

namespace AutoYa_Backend.AutoYa.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<BodyInformation, BodyInformationResource>();
        CreateMap<CarDocumentation, CarDocumentationResource>();
        CreateMap<CarPhoto, CarPhotoResource>();
        CreateMap<Car, CarResource>();
        CreateMap<CarReview, CarReviewResource>();
        CreateMap<Destination, DestinationResource>();
        CreateMap<MessagePhoto, MessagePhotoResource>();
        CreateMap<Message, MessageResource>();
        CreateMap<Notification, NotificationResource>();
        CreateMap<Propietary, PropietaryResource>();
        CreateMap<Rent, RentResource>();
        CreateMap<Request, RequestResource>();
        CreateMap<Review, ReviewResource>();
        CreateMap<Tenant, TenantResource>();
        CreateMap<User, UserResource>();
    }
}