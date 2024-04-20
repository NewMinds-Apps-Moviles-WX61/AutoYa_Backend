using AutoMapper;
using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Services;
using AutoYa_Backend.AutoYa.Resources.GET;
using AutoYa_Backend.AutoYa.Resources.POST;
using AutoYa_Backend.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AutoYa_Backend.AutoYa.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class CarReviewsController : ControllerBase
{
    private readonly ICarReviewService _carReviewService;
    private readonly IMapper _mapper;

    public CarReviewsController(ICarReviewService carReviewService, IMapper mapper)
    {
        _carReviewService = carReviewService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<CarReviewResource>> GetAllAsync()
    {
        var carReviews = await _carReviewService.ListAsync();
        var resources = _mapper.Map<IEnumerable<CarReview>, IEnumerable<CarReviewResource>>(carReviews);

        return resources;
    }

    [HttpGet("{carId}")]
    public async Task<IEnumerable<CarReviewResource>> GetByCarIdAsync(int carId)
    {
        var carReviews = await _carReviewService.GetByCarIdAsync(carId);
        var resources = _mapper.Map<IEnumerable<CarReview>, IEnumerable<CarReviewResource>>(carReviews);
        
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveCarReviewResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var carReview = _mapper.Map<SaveCarReviewResource, CarReview>(resource);
        var bodyInformation = _mapper.Map<SaveCarReviewResource, BodyInformation>(resource);
        var result = await _carReviewService.SaveAsync(carReview, bodyInformation);

        if (!result.Success)
            return BadRequest(result.Message);

        var carReviewResource = _mapper.Map<CarReview, CarReviewResource>(result.Resource);

        return Ok(carReviewResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCarReviewResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var carReview = _mapper.Map<SaveCarReviewResource, CarReview>(resource);
        var bodyInformation = _mapper.Map<SaveCarReviewResource, BodyInformation>(resource);
        var result = await _carReviewService.UpdateAsync(id, carReview, bodyInformation);

        if (!result.Success)
            return BadRequest(result.Message);

        var carReviewResource = _mapper.Map<CarReview, CarReviewResource>(result.Resource);

        return Ok(carReviewResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _carReviewService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var carReviewResource = _mapper.Map<CarReview, CarReviewResource>(result.Resource);

        return Ok(carReviewResource);
    }
}