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
public class PropietariesController : ControllerBase
{
    private readonly IPropietaryService _propietaryService;
    private readonly IMapper _mapper;

    public PropietariesController(IPropietaryService propietaryService, IMapper mapper)
    {
        _propietaryService = propietaryService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<PropietaryResource>> GetAllAsync()
    {
        var propietaries = await _propietaryService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Propietary>, IEnumerable<PropietaryResource>>(propietaries);
        
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SavePropietaryResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var propietary = _mapper.Map<SavePropietaryResource, Propietary>(resource);
        var user = _mapper.Map<SavePropietaryResource, User>(resource);
        var result = await _propietaryService.SaveAsync(propietary, user);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var propietaryResource = _mapper.Map<Propietary, PropietaryResource>(result.Resource);
        
        return Ok(propietaryResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SavePropietaryResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var propietary = _mapper.Map<SavePropietaryResource, Propietary>(resource);
        var user = _mapper.Map<SavePropietaryResource, User>(resource);
        var result = await _propietaryService.UpdateAsync(id, propietary, user);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var propietaryResource = _mapper.Map<Propietary, PropietaryResource>(result.Resource);
        
        return Ok(propietaryResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _propietaryService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var propietaryResource = _mapper.Map<Propietary, PropietaryResource>(result.Resource);
        
        return Ok(propietaryResource);
    }
}