using LicenseServer.Domain.Entities;

namespace LicenseServer.Data.Interfaces;

public interface IGenericRepository<T> where T : Base
{
    Task<byte> CreateAsync(T entity);
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<byte> UpdateAsync(T entity);
    Task<byte> DeleteAsync(T entity);
}
