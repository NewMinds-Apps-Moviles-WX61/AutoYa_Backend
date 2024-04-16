using AutoMapper;
using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Services;
using AutoYa_Backend.AutoYa.Resources.GET;
using AutoYa_Backend.AutoYa.Resources.POST;
using AutoYa_Backend.AutoYa.Resources.PUT;
using AutoYa_Backend.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AutoYa_Backend.AutoYa.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class ReviewsControllers : ControllerBase
{
    private readonly IReviewService _reviewService;
    private readonly IMapper _mapper;

    public ReviewsControllers(IReviewService reviewService, IMapper mapper)
    {
        _reviewService = reviewService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<ReviewResource>> GetAllAsync()
    {
        var propietaries = await _reviewService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Review>, IEnumerable<ReviewResource>>(propietaries);
        
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveReviewResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var review = _mapper.Map<SaveReviewResource, Review>(resource);
        var bodyInformation = _mapper.Map<SaveReviewResource, BodyInformation>(resource);
        var destination = _mapper.Map<SaveReviewResource, Destination>(resource);
        var result = await _reviewService.SaveAsync(review, bodyInformation, destination);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var reviewResource = _mapper.Map<Review, ReviewResource>(result.Resource);
        
        return Ok(reviewResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] UpdateReviewResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var review = _mapper.Map<UpdateReviewResource, Review>(resource);
        var bodyInformation = _mapper.Map<UpdateReviewResource, BodyInformation>(resource);
        var result = await _reviewService.UpdateAsync(id, review, bodyInformation);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var reviewResource = _mapper.Map<Review, ReviewResource>(result.Resource);
        
        return Ok(reviewResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _reviewService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var reviewResource = _mapper.Map<Review, ReviewResource>(result.Resource);
        
        return Ok(reviewResource);
    }
}