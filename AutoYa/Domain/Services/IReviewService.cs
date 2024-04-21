using AutoYa_Backend.AutoYa.Domain.Communication;
using AutoYa_Backend.AutoYa.Domain.Models;

namespace AutoYa_Backend.AutoYa.Domain.Services;

public interface IReviewService
{
    Task<IEnumerable<Review>> ListAsync();
    Task<Review> GetByPropietaryIdTenantIdIssuerAndCategoryAsync(int propietaryId, int tenantId, string issuer, string category);
    Task<ReviewResponse> SaveAsync(Review review, BodyInformation bodyInformation, Destination destination);
    Task<ReviewResponse> UpdateAsync(int id, Review review, BodyInformation bodyInformation);
    Task<ReviewResponse> DeleteAsync(int id);
}