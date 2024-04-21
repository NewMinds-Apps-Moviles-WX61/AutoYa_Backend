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
public class RequestsController : ControllerBase
{
    private readonly IRequestService _requestService;
    private readonly IMapper _mapper;

    public RequestsController(IRequestService requestService, IMapper mapper)
    {
        _requestService = requestService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<RequestResource>> GetAllAsync()
    {
        var requests = await _requestService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Request>, IEnumerable<RequestResource>>(requests);

        return resources;
    }

    [HttpGet("{carId}")]
    public async Task<IEnumerable<RequestResource>> GetAllByPropietaryIdAsync(int carId)
    {
        var requests = await _requestService.ListByPropietaryIdAsync(carId);
        var resources = _mapper.Map<IEnumerable<Request>, IEnumerable<RequestResource>>(requests);

        return resources;
    }

    [HttpGet("plate/{plate}")]
    public async Task<IEnumerable<RequestResource>> GetAllByPlateAsync(string plate)
    {
        var request = await _requestService.ListByPlateAsync(plate);
        var resource = _mapper.Map<IEnumerable<Request>, IEnumerable<RequestResource>>(request);

        return resource;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveRequestResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var request = _mapper.Map<SaveRequestResource, Request>(resource);
        var result = await _requestService.SaveAsync(request);

        if (!result.Success)
            return BadRequest(result.Message);

        var requestResource = _mapper.Map<Request, RequestResource>(result.Resource);

        return Ok(requestResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveRequestResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var request = _mapper.Map<SaveRequestResource, Request>(resource);
        var result = await _requestService.UpdateAsync(id, request);

        if (!result.Success)
            return BadRequest(result.Message);

        var requestResource = _mapper.Map<Request, RequestResource>(result.Resource);

        return Ok(requestResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _requestService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var requestResource = _mapper.Map<Request, RequestResource>(result.Resource);

        return Ok(requestResource);
    }
}