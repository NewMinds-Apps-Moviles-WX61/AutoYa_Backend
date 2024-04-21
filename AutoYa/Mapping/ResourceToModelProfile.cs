using AutoMapper;
using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Resources.AuxiliarEntities;
using AutoYa_Backend.AutoYa.Resources.GET;
using AutoYa_Backend.AutoYa.Resources.POST;
using AutoYa_Backend.AutoYa.Resources.PUT;

namespace AutoYa_Backend.AutoYa.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<GetCarByAttributes, CarSearchParams>();
        CreateMap<UpdateReviewResource, BodyInformation>();
        CreateMap<UpdateReviewResource, Review>();
        CreateMap<UpdateCarStatusResource, Car>();
        CreateMap<SaveBodyInformationResource, BodyInformation>();
        CreateMap<SaveCarDocumentationResource, CarDocumentation>();
        CreateMap<SaveCarPhotoResource, CarPhoto>();
        CreateMap<SaveCarResource, Car>();
        CreateMap<SaveCarReviewResource, CarReview>();
        CreateMap<SaveCarReviewResource, BodyInformation>();
        CreateMap<SaveDestinationResource, Destination>();
        CreateMap<SaveMessagePhotoResource, MessagePhoto>();
        CreateMap<SaveMessageResource, Message>();
        CreateMap<SaveMessageResource, BodyInformation>();
        CreateMap<SaveMessageResource, Destination>();
        CreateMap<SaveNotificationResource, Notification>();
        CreateMap<SavePropietaryResource, Propietary>();
        CreateMap<SavePropietaryResource, User>();
        CreateMap<SaveRentResource, Rent>();
        CreateMap<SaveRequestResource, Request>();
        CreateMap<SaveReviewResource, BodyInformation>();
        CreateMap<SaveReviewResource, Destination>();
        CreateMap<SaveReviewResource, Review>();
        CreateMap<SaveTenantResource, Tenant>();
        CreateMap<SaveTenantResource, User>();
        CreateMap<SaveUserResource, User>();
    }
}