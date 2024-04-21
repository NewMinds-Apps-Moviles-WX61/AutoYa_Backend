using AutoYa_Backend.AutoYa.Domain.Communication;
using AutoYa_Backend.AutoYa.Domain.Models;

namespace AutoYa_Backend.AutoYa.Domain.Services;

public interface IRequestService
{
    Task<IEnumerable<Request>> ListAsync();
    Task<IEnumerable<Request>> ListByPropietaryIdAsync(int id);
    Task<IEnumerable<Request>> ListByPlateAsync(string plate);
    Task<RequestResponse> SaveAsync(Request request);
    Task<RequestResponse> UpdateAsync(int id, Request request);
    Task<RequestResponse> DeleteAsync(int id);
}