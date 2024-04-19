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
public class CarDocumentationsController : ControllerBase
{
    private readonly ICarDocumentationService _carDocumentationService;
    private readonly IMapper _mapper;

    public CarDocumentationsController(ICarDocumentationService carDocumentationService, IMapper mapper)
    {
        _carDocumentationService = carDocumentationService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<CarDocumentationResource>> GetAllAsync()
    {
        var carDocumentations = await _carDocumentationService.ListAsync();
        var resources = _mapper.Map<IEnumerable<CarDocumentation>, IEnumerable<CarDocumentationResource>>(carDocumentations);

        return resources;
    }

    [HttpGet("{carId}")]
    public async Task<IEnumerable<CarDocumentationResource>> GetAllByCarIdAsync(int carId)
    {
        var carDocumentations = await _carDocumentationService.ListByCarIdAsync(carId);
        var resources = _mapper.Map<IEnumerable<CarDocumentation>, IEnumerable<CarDocumentationResource>>(carDocumentations);

        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveCarDocumentationResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var carDocumentation = _mapper.Map<SaveCarDocumentationResource, CarDocumentation>(resource);
        var result = await _carDocumentationService.SaveAsync(carDocumentation);

        if (!result.Success)
            return BadRequest(result.Message);

        var carDocumentationResource = _mapper.Map<CarDocumentation, CarDocumentationResource>(result.Resource);

        return Ok(carDocumentationResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _carDocumentationService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var carDocumentationResource = _mapper.Map<CarDocumentation, CarDocumentationResource>(result.Resource);

        return Ok(carDocumentationResource);
    }
}