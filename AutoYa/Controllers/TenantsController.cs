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
public class TenantsController : ControllerBase
{
    private readonly ITenantService _tenantService;
    private readonly IMapper _mapper;

    public TenantsController(ITenantService tenantService, IMapper mapper)
    {
        _tenantService = tenantService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<TenantResource>> GetAllAsync()
    {
        var propietaries = await _tenantService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Tenant>, IEnumerable<TenantResource>>(propietaries);
        
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveTenantResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var tenant = _mapper.Map<SaveTenantResource, Tenant>(resource);
        var user = _mapper.Map<SaveTenantResource, User>(resource);
        var result = await _tenantService.SaveAsync(tenant, user);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var tenantResource = _mapper.Map<Tenant, TenantResource>(result.Resource);
        
        return Ok(tenantResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveTenantResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var tenant = _mapper.Map<SaveTenantResource, Tenant>(resource);
        var user = _mapper.Map<SaveTenantResource, User>(resource);
        var result = await _tenantService.UpdateAsync(id, tenant, user);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var tenantResource = _mapper.Map<Tenant, TenantResource>(result.Resource);
        
        return Ok(tenantResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _tenantService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var tenantResource = _mapper.Map<Tenant, TenantResource>(result.Resource);
        
        return Ok(tenantResource);
    }
}