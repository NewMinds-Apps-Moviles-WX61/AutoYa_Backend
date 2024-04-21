using AutoYa_Backend.AutoYa.Domain.Communication;
using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.AutoYa.Domain.Services;

namespace AutoYa_Backend.AutoYa.Services;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IBodyInformationRepository _bodyInformationRepository;
    private readonly IDestinationRepository _destinationRepository;
    private readonly IPropietaryRepository _propietaryRepository;
    private readonly ITenantRepository _tenantRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ReviewService(IReviewRepository reviewRepository, IBodyInformationRepository bodyInformationRepository, IDestinationRepository destinationRepository, IUnitOfWork unitOfWork, IPropietaryRepository propietaryRepository, ITenantRepository tenantRepository)
    {
        _reviewRepository = reviewRepository;
        _bodyInformationRepository = bodyInformationRepository;
        _destinationRepository = destinationRepository;
        _unitOfWork = unitOfWork;
        _propietaryRepository = propietaryRepository;
        _tenantRepository = tenantRepository;
    }

    public async Task<IEnumerable<Review>> ListAsync()
    {
        return await _reviewRepository.ListAsync();
    }

    public async Task<Review> GetByPropietaryIdTenantIdIssuerAndCategoryAsync(int propietaryId, int tenantId, string issuer, string category)
    {
        // Se obtiene el ID del destinatario en una lista porque este mismo método de DestinationRepository se usa en otros casos que devuelven más de un valor
        var destinationIds = await _destinationRepository.ListDestinationIdsByPropietaryIdTenantIdIssuerAndCategoryAsync(propietaryId, tenantId, issuer, category);

        // Como destinationIds es una lista que solo tendrá un elemento, se extrae el primer elemento
        var destinationId = destinationIds.First();
        
        return await _reviewRepository.FindByDestinationIdAsync(destinationId);
    }

    public async Task<ReviewResponse> SaveAsync(Review review, BodyInformation bodyInformation, Destination destination)
    {
        try
        {
            var existingPropietary = await _propietaryRepository.FindByIdAsync(destination.PropietaryId);
            
            if (existingPropietary == null)
                return new ReviewResponse("Propietary not found.");
            
            var existingTenant = await _tenantRepository.FindByIdAsync(destination.TenantId);
            
            if (existingTenant == null)
                return new ReviewResponse("Tenant not found.");
            
            var existingDestination = await _destinationRepository.FindByIssuerPropietaryIdTenantIdAndCategoryAsync(
                    destination.Issuer, 
                    destination.PropietaryId,
                    destination.TenantId,
                    destination.Category);
            
            if (existingDestination != null)
                return new ReviewResponse("Review with that issuer, propietaryId and tenantId already exists.");
            
            await _bodyInformationRepository.AddAsync(bodyInformation);
            await _unitOfWork.CompleteAsync();

            // Obtener el ID del bodyInformation generado automáticamente
            var bodyInformationId = bodyInformation.Id;
            
            await _destinationRepository.AddAsync(destination);
            await _unitOfWork.CompleteAsync();
            
            // Obtener el ID del destination generado automaticamente
            var destinationId = destination.Id;

            // Asignar los IDs autogenerados al review
            review.BodyInformationId = bodyInformationId;
            review.DestinationId = destinationId;
            
            await _reviewRepository.AddAsync(review);
            await _unitOfWork.CompleteAsync();
            return new ReviewResponse(review);
        }
        catch (Exception e)
        {
            return new ReviewResponse($"An error occurred while saving the review: {e.Message}");
        }
    }

    public async Task<ReviewResponse> UpdateAsync(int id, Review review, BodyInformation bodyInformation)
    {
        var existingReview = await _reviewRepository.FindByIdAsync(id);
        
        if (existingReview == null)
            return new ReviewResponse("Review not found.");
        
        var existingBodyInformation = await _bodyInformationRepository.FindByIdAsync(existingReview.BodyInformationId);
        
        if (existingBodyInformation == null)
            return new ReviewResponse("BodyInformation not found.");

        existingReview.Score = review.Score;
        
        existingBodyInformation.Text = bodyInformation.Text;
        existingBodyInformation.Date = bodyInformation.Date;
        existingBodyInformation.Time = bodyInformation.Time;
        
        try
        {
            _reviewRepository.Update(existingReview);
            await _unitOfWork.CompleteAsync();
            _bodyInformationRepository.Update(existingBodyInformation);
            await _unitOfWork.CompleteAsync();
            return new ReviewResponse(existingReview);
        }
        catch (Exception e)
        {
            return new ReviewResponse($"An error occurred while updating the review: {e.Message}");
        }
    }

    public async Task<ReviewResponse> DeleteAsync(int id)
    {
        var existingReview = await _reviewRepository.FindByIdAsync(id);
        
        if (existingReview == null)
            return new ReviewResponse("Review not found.");
        
        var existingBodyInformation = await _bodyInformationRepository.FindByIdAsync(existingReview.BodyInformationId);
        
        if (existingBodyInformation == null)
            return new ReviewResponse("BodyInformation not found.");
        
        var existingDestination = await _destinationRepository.FindByIdAsync(existingReview.DestinationId);
        
        if (existingDestination == null)
            return new ReviewResponse("Destination not found.");
        
        try
        {
            _reviewRepository.Remove(existingReview);
            await _unitOfWork.CompleteAsync();
            _bodyInformationRepository.Remove(existingBodyInformation);
            await _unitOfWork.CompleteAsync();
            _destinationRepository.Remove(existingDestination);
            await _unitOfWork.CompleteAsync();
            return new ReviewResponse(existingReview);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new ReviewResponse($"An error occurred while deleting the review: {e.Message}");
        }
    }
}