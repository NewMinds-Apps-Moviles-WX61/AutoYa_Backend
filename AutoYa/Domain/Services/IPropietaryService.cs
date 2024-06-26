﻿using AutoYa_Backend.AutoYa.Domain.Communication;
using AutoYa_Backend.AutoYa.Domain.Models;

namespace AutoYa_Backend.AutoYa.Domain.Services;

public interface IPropietaryService
{
    Task<IEnumerable<Propietary>> ListAsync();
    Task<Propietary> GetByIdAsync(int id);
    Task<Propietary> GetByUserIdAsync(int userId);
    Task<PropietaryResponse> SaveAsync(Propietary propietary, User user);
    Task<PropietaryResponse> UpdateAsync(int id, Propietary propietary, User user);
    Task<PropietaryResponse> DeleteAsync(int id);
}