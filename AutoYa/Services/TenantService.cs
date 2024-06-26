using AutoYa_Backend.AutoYa.Domain.Communication;
using AutoYa_Backend.AutoYa.Domain.Models;
using AutoYa_Backend.AutoYa.Domain.Repositories;
using AutoYa_Backend.AutoYa.Domain.Services;

namespace AutoYa_Backend.AutoYa.Services;

public class TenantService : ITenantService
{
    private readonly ITenantRepository _tenantRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TenantService(ITenantRepository tenantRepository, IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _tenantRepository = tenantRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Tenant>> ListAsync()
    {
        return await _tenantRepository.ListAsync();
    }

    public async Task<Tenant> GetByIdAsync(int id)
    {
        return await _tenantRepository.FindByIdAsync(id);
    }

    public async Task<Tenant> GetByUserIdAsync(int userId)
    {
        return await _tenantRepository.FindByUserIdAsync(userId);
    }

    public async Task<TenantResponse> SaveAsync(Tenant tenant, User user)
    {
        try
        {
            var existingEmail = await _userRepository.FindByEmailAsync(user.Email);
            var existingDNI = await _userRepository.FindByDniAsync(user.DNI);
            
            if (existingEmail != null)
                return new TenantResponse("User with that email already exists.");
            
            if (existingDNI != null)
                return new TenantResponse("User with that DNI already exists.");
            
            user.Type = "TENANT";
            
            await _userRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();

            // Obtener el ID del usuario generado automáticamente
            int userId = user.Id;

            // Asignar el ID del usuario al propietario
            tenant.UserId = userId;
            
            await _tenantRepository.AddAsync(tenant);
            await _unitOfWork.CompleteAsync();
            return new TenantResponse(tenant);
        }
        catch (Exception e)
        {
            return new TenantResponse($"An error occurred while saving the tenant: {e.Message}");
        }
    }

    public async Task<TenantResponse> UpdateAsync(int id, Tenant tenant, User user)
    {
        var existingTenant = await _tenantRepository.FindByIdAsync(id);
        
        if (existingTenant == null)
            return new TenantResponse("Tenant not found.");
        
        var existingUser = await _userRepository.FindByIdAsync(existingTenant.UserId);
        
        if (existingUser == null)
            return new TenantResponse("User not found.");
        
        existingTenant.CriminalRecordURL = tenant.CriminalRecordURL;
        existingUser.Name = user.Name;
        existingUser.PhoneNumber = user.PhoneNumber;
        existingUser.PhotoURL = user.PhotoURL;
        
        try
        {
            _tenantRepository.Update(existingTenant);
            await _unitOfWork.CompleteAsync();
            _userRepository.Update(existingUser);
            await _unitOfWork.CompleteAsync();
            return new TenantResponse(existingTenant);
        }
        catch (Exception e)
        {
            return new TenantResponse($"An error occurred while updating the tenant: {e.Message}");
        }
    }

    public async Task<TenantResponse> DeleteAsync(int id)
    {
        var existingTenant = await _tenantRepository.FindByIdAsync(id);
        
        if (existingTenant == null)
            return new TenantResponse("Tenant not found.");
        
        var existingUser = await _userRepository.FindByIdAsync(existingTenant.UserId);
        
        if (existingUser == null)
            return new TenantResponse("User not found.");
        
        try
        {
            _tenantRepository.Remove(existingTenant);
            await _unitOfWork.CompleteAsync();
            _userRepository.Remove(existingUser);
            await _unitOfWork.CompleteAsync();
            return new TenantResponse(existingTenant);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new TenantResponse($"An error occurred while deleting the tenant: {e.Message}");
        }
    }
}