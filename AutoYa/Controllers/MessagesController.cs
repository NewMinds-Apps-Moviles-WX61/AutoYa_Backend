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
public class MessagesController : ControllerBase
{
    private readonly IMessageService _messageService;
    private readonly IMapper _mapper;

    public MessagesController(IMessageService messageService, IMapper mapper)
    {
        _messageService = messageService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<MessageResource>> GetAllAsync()
    {
        var messages = await _messageService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Message>, IEnumerable<MessageResource>>(messages);
        
        return resources;
    }

    [HttpGet("{propietaryId}/{tenantId}/{issuer}/{category}")]
    public async Task<IEnumerable<MessageResource>> GetAllByPropietaryIdTenantIdIssuerAndCategoryAsync(int propietaryId, int tenantId, string issuer, string category)
    {
        var messages = await _messageService.GetAllByPropietaryIdTenantIdIssuerAndCategoryAsync(propietaryId, tenantId, issuer, category);
        var resources = _mapper.Map<IEnumerable<Message>, IEnumerable<MessageResource>>(messages);
        
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveMessageResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var message = _mapper.Map<SaveMessageResource, Message>(resource);
        var bodyInformation = _mapper.Map<SaveMessageResource, BodyInformation>(resource);
        var destination = _mapper.Map<SaveMessageResource, Destination>(resource);
        var result = await _messageService.SaveAsync(message, bodyInformation, destination);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var messageResource = _mapper.Map<Message, MessageResource>(result.Resource);
        
        return Ok(messageResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveMessageResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var message = _mapper.Map<SaveMessageResource, Message>(resource);
        var bodyInformation = _mapper.Map<SaveMessageResource, BodyInformation>(resource);
        var result = await _messageService.UpdateAsync(id, bodyInformation);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var messageResource = _mapper.Map<Message, MessageResource>(result.Resource);
        
        return Ok(messageResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _messageService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var messageResource = _mapper.Map<Message, MessageResource>(result.Resource);
        
        return Ok(messageResource);
    }
}