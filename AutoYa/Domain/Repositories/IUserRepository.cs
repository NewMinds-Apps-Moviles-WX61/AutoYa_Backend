using AutoYa_Backend.AutoYa.Domain.Models;

namespace AutoYa_Backend.AutoYa.Domain.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> ListAsync();
    Task AddAsync(User user);
    Task<User> FindByIdAsync(int id);
    Task<User> FindByEmailAsync(string email);
    Task<User> FindByDniAsync(string dni);
    Task<User> FindUserByEmailAndPasswordAsync(string email, string password);
    void Update(User user);
    void Remove(User user);
}