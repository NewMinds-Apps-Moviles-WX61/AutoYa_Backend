using AutoYa_Backend.AutoYa.Domain.Communication;
using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.AutoYa.Domain.Services;

namespace AutoYa_Backend.AutoYa.Services;

public class PropietaryService : IPropietaryService
{
    private readonly IPropietaryRepository _propietaryRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PropietaryService(IPropietaryRepository propietaryRepository, IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _propietaryRepository = propietaryRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<Propietary>> ListAsync()
    {
        return await _propietaryRepository.ListAsync();
    }

    public async Task<Propietary> GetByIdAsync(int id)
    {
        return await _propietaryRepository.FindByIdAsync(id);
    }

    public async Task<Propietary> GetByUserIdAsync(int userId)
    {
        return await _propietaryRepository.FindByUserIdAsync(userId);
    }

    public async Task<PropietaryResponse> SaveAsync(Propietary propietary, User user)
    {
        try
        {
            var existingEmail = await _userRepository.FindByEmailAsync(user.Email);
            var existingDNI = await _userRepository.FindByDniAsync(user.DNI);
            
            if (existingEmail != null)
                return new PropietaryResponse("User with that email already exists.");
            
            if (existingDNI != null)
                return new PropietaryResponse("User with that DNI already exists.");
            
            user.Type = "PROPIETARY";
            
            await _userRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();

            // Obtener el ID del usuario generado automáticamente
            var userId = user.Id;

            // Asignar el ID del usuario al propietario
            propietary.UserId = userId;
            
            await _propietaryRepository.AddAsync(propietary);
            await _unitOfWork.CompleteAsync();
            return new PropietaryResponse(propietary);
        }
        catch (Exception e)
        {
            return new PropietaryResponse($"An error occurred while saving the propietary: {e.Message}");
        }
    }

    public async Task<PropietaryResponse> UpdateAsync(int id, Propietary propietary, User user)
    {
        var existingPropietary = await _propietaryRepository.FindByIdAsync(id);
        
        if (existingPropietary == null)
            return new PropietaryResponse("Propietary not found.");
        
        existingPropietary.ContractURL = propietary.ContractURL;
        
        var existingUser = await _userRepository.FindByIdAsync(existingPropietary.UserId);
        
        if (existingUser == null)
            return new PropietaryResponse("User not found.");
        
        existingUser.Name = user.Name;
        existingUser.PhoneNumber = user.PhoneNumber;
        existingUser.PhotoURL = user.PhotoURL;
        
        try
        {
            _propietaryRepository.Update(existingPropietary);
            await _unitOfWork.CompleteAsync();
            _userRepository.Update(existingUser);
            await _unitOfWork.CompleteAsync();
            return new PropietaryResponse(existingPropietary);
        }
        catch (Exception e)
        {
            return new PropietaryResponse($"An error occurred while updating the propietary: {e.Message}");
        }
    }

    public async Task<PropietaryResponse> DeleteAsync(int id)
    {
        var existingPropietary = await _propietaryRepository.FindByIdAsync(id);
        
        if (existingPropietary == null)
            return new PropietaryResponse("Propietary not found.");
        
        var existingUser = await _userRepository.FindByIdAsync(existingPropietary.UserId);
        
        if (existingUser == null)
            return new PropietaryResponse("User not found.");
        
        try
        {
            _propietaryRepository.Remove(existingPropietary);
            await _unitOfWork.CompleteAsync();
            _userRepository.Remove(existingUser);
            await _unitOfWork.CompleteAsync();
            return new PropietaryResponse(existingPropietary);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new PropietaryResponse($"An error occurred while deleting the propietary: {e.Message}");
        }
    }
}