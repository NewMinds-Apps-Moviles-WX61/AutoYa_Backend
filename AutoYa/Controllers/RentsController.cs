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
public class RentsController : ControllerBase
{
    private readonly IRentService _rentService;
    private readonly IMapper _mapper;

    public RentsController(IRentService rentService, IMapper mapper)
    {
        _rentService = rentService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<RentResource>> GetAllAsync()
    {
        var requests = await _rentService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Rent>, IEnumerable<RentResource>>(requests);

        return resources;
    }

    [HttpGet("propietary/{propietaryId:int}")]
    public async Task<IEnumerable<RentResource>> GetAllByPropietaryIdAsync(int propietaryId)
    {
        var requests = await _rentService.ListByPropietaryIdAsync(propietaryId);
        var resources = _mapper.Map<IEnumerable<Rent>, IEnumerable<RentResource>>(requests);

        return resources;
    }
    
    [HttpGet("tenant/{tenantId:int}")]
    public async Task<IEnumerable<RentResource>> GetAllRentsByTenantIdAsync(int tenantId)
    {
        var request = await _rentService.ListAllRentsByTenantIdAsync(tenantId);
        var resources = _mapper.Map<IEnumerable<Rent>, IEnumerable<RentResource>>(request);
        
        return resources;
    }

    [HttpGet("plate/{plate}")]
    public async Task<IEnumerable<RentResource>> GetAllByPlateAsync(string plate)
    {
        var request = await _rentService.ListByPlateAsync(plate);
        var resource = _mapper.Map<IEnumerable<Rent>, IEnumerable<RentResource>>(request);

        return resource;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveRentResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var request = _mapper.Map<SaveRentResource, Rent>(resource);
        var result = await _rentService.SaveAsync(request);

        if (!result.Success)
            return BadRequest(result.Message);

        var requestResource = _mapper.Map<Rent, RentResource>(result.Resource);

        return Ok(requestResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveRentResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var request = _mapper.Map<SaveRentResource, Rent>(resource);
        var result = await _rentService.UpdateAsync(id, request);

        if (!result.Success)
            return BadRequest(result.Message);

        var requestResource = _mapper.Map<Rent, RentResource>(result.Resource);

        return Ok(requestResource);
    }
    
    [HttpPut("put-accepted/{id:int}")]
    public async Task<IActionResult> PutAcceptedAsync(int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var result = await _rentService.UpdateRentStatusAsync(id, "ACCEPTED");
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var requestResource = _mapper.Map<Rent, RentResource>(result.Resource);
        
        return Ok(requestResource);
    }
    
    [HttpPut("put-rejected/{id:int}")]
    public async Task<IActionResult> PutRejectedAsync(int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var result = await _rentService.UpdateRentStatusAsync(id, "REJECTED");
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var requestResource = _mapper.Map<Rent, RentResource>(result.Resource);
        
        return Ok(requestResource);
    }
    
    [HttpPut("put-cancelled/{id:int}")]
    public async Task<IActionResult> PutCancelledAsync(int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var result = await _rentService.UpdateRentStatusAsync(id, "CANCELLED");
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var requestResource = _mapper.Map<Rent, RentResource>(result.Resource);
        
        return Ok(requestResource);
    }
    
    [HttpPut("put-finished/{id:int}")]
    public async Task<IActionResult> PutFinishedAsync(int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var result = await _rentService.UpdateRentStatusAsync(id, "FINISHED");
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var requestResource = _mapper.Map<Rent, RentResource>(result.Resource);
        
        return Ok(requestResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _rentService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var requestResource = _mapper.Map<Rent, RentResource>(result.Resource);

        return Ok(requestResource);
    }
}