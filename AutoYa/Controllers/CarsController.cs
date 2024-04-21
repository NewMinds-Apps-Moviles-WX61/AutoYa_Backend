using AutoMapper;
using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Services;
using AutoYa_Backend.AutoYa.Resources.AuxiliarEntities;
using AutoYa_Backend.AutoYa.Resources.GET;
using AutoYa_Backend.AutoYa.Resources.POST;
using AutoYa_Backend.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AutoYa_Backend.AutoYa.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class CarsController : ControllerBase
{
    private readonly ICarService _carService;
    private readonly IMapper _mapper;
    
    public CarsController(ICarService carService, IMapper mapper)
    {
        _carService = carService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<CarResource>> GetAllAsync()
    {
        var cars = await _carService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Car>, IEnumerable<CarResource>>(cars);
        
        return resources;
    }

    [HttpPost("search")]
    public async Task<IActionResult> GetByAttributesAsync([FromBody] GetCarByAttributes resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var carSearchParams = _mapper.Map<GetCarByAttributes, CarSearchParams>(resource);
        var cars = await _carService.GetByAttributesAsync(carSearchParams);

        if (!cars.Any())
            return NotFound();

        var carResources = _mapper.Map<IEnumerable<Car>, IEnumerable<CarResource>>(cars);

        return Ok(carResources);
    }
    

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveCarResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var car = _mapper.Map<SaveCarResource, Car>(resource);
        var result = await _carService.SaveAsync(car);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var carResource = _mapper.Map<Car, CarResource>(result.Resource);
        
        return Ok(carResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCarResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var car = _mapper.Map<SaveCarResource, Car>(resource);
        var result = await _carService.UpdateAsync(id, car);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var carResource = _mapper.Map<Car, CarResource>(result.Resource);
        
        return Ok(carResource);
    }
    
    /*
    [HttpPut("{id}/status")]
    public async Task<IActionResult> PutStatusAsync(int id, [FromBody] UpdateCarStatusResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var car = _mapper.Map<UpdateCarStatusResource, Car>(resource);
        var result = await _carService.UpdateStatusAsync(id, car);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var carResource = _mapper.Map<Car, CarResource>(result.Resource);
        
        return Ok(carResource);
    }*/

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _carService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var carResource = _mapper.Map<Car, CarResource>(result.Resource);
        
        return Ok(carResource);
    }
}