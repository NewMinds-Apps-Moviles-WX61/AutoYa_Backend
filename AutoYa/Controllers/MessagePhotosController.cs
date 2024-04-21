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
public class MessagePhotosController : ControllerBase
{
    private readonly IMessagePhotoService _messagePhotoService;
    private readonly IMapper _mapper;

    public MessagePhotosController(IMessagePhotoService messagePhotoService, IMapper mapper)
    {
        _messagePhotoService = messagePhotoService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<MessagePhotoResource>> GetAllAsync()
    {
        var messagePhotos = await _messagePhotoService.ListAsync();
        var resources = _mapper.Map<IEnumerable<MessagePhoto>, IEnumerable<MessagePhotoResource>>(messagePhotos);

        return resources;
    }

    [HttpGet("{messageId}")]
    public async Task<IEnumerable<MessagePhotoResource>> GetAllByMessageIdAsync(int messageId)
    {
        var messagePhotos = await _messagePhotoService.ListByMessageIdAsync(messageId);
        var resources = _mapper.Map<IEnumerable<MessagePhoto>, IEnumerable<MessagePhotoResource>>(messagePhotos);

        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveMessagePhotoResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var messagePhoto = _mapper.Map<SaveMessagePhotoResource, MessagePhoto>(resource);
        var result = await _messagePhotoService.SaveAsync(messagePhoto);

        if (!result.Success)
            return BadRequest(result.Message);

        var messagePhotoResource = _mapper.Map<MessagePhoto, MessagePhotoResource>(result.Resource);

        return Ok(messagePhotoResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _messagePhotoService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var messagePhotoResource = _mapper.Map<MessagePhoto, MessagePhotoResource>(result.Resource);

        return Ok(messagePhotoResource);
    }
}