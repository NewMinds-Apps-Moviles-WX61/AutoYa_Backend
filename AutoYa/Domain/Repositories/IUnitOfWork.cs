namespace AutoYa_Backend.AutoYa.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}