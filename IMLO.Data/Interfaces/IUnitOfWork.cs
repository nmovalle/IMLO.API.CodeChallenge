namespace IMLO.Data.Interfaces;

public interface IUnitOfWork : IDisposable
{
    Task<int> CompleteAsync();
}
