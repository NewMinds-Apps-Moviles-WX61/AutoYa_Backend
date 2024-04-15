using AutoMapper;
using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Resources.POST;

namespace AutoYa_Backend.AutoYa.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveBodyInformationResource, BodyInformation>();
        CreateMap<SaveCarDocumentationResource, CarDocumentation>();
        CreateMap<SaveCarPhotoResource, CarPhoto>();
        CreateMap<SaveCarResource, Car>();
        CreateMap<SaveCarReviewResource, CarReview>();
        CreateMap<SaveDestinationResource, Destination>();
        CreateMap<SaveMessagePhotoResource, MessagePhoto>();
        CreateMap<SaveMessageResource, Message>();
        CreateMap<SaveNotificationResource, Notification>();
        CreateMap<SavePropietaryResource, Propietary>();
        CreateMap<SavePropietaryResource, User>();
        CreateMap<SaveRentResource, Rent>();
        CreateMap<SaveRequestResource, Request>();
        CreateMap<SaveReviewResource, Review>();
        CreateMap<SaveTenantResource, Tenant>();
        CreateMap<SaveTenantResource, User>();
        CreateMap<SaveUserResource, User>();
    }
}