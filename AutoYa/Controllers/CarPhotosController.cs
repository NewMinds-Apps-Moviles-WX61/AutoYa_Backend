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
public class CarPhotosController : ControllerBase
{
    private readonly ICarPhotoService _carPhotoService;
    private readonly IMapper _mapper;

    public CarPhotosController(ICarPhotoService carPhotoService, IMapper mapper)
    {
        _carPhotoService = carPhotoService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<CarPhotoResource>> GetAllAsync()
    {
        var carPhotos = await _carPhotoService.ListAsync();
        var resources = _mapper.Map<IEnumerable<CarPhoto>, IEnumerable<CarPhotoResource>>(carPhotos);
        
        return resources;
    }
    
    [HttpGet("{carId}")]
    public async Task<IEnumerable<CarPhotoResource>> GetAllByCarIdAsync(int carId)
    {
        var carPhotos = await _carPhotoService.ListByCarIdAsync(carId);
        var resources = _mapper.Map<IEnumerable<CarPhoto>, IEnumerable<CarPhotoResource>>(carPhotos);
        
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveCarPhotoResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var carPhoto = _mapper.Map<SaveCarPhotoResource, CarPhoto>(resource);
        var result = await _carPhotoService.SaveAsync(carPhoto);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var carPhotoResource = _mapper.Map<CarPhoto, CarPhotoResource>(result.Resource);
        
        return Ok(carPhotoResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _carPhotoService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var carPhotoResource = _mapper.Map<CarPhoto, CarPhotoResource>(result.Resource);
        
        return Ok(carPhotoResource);
    }
}