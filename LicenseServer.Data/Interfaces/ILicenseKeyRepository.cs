using LicenseServer.Domain.Entities;

namespace LicenseServer.Data.Interfaces;

public interface ILicenseKeyRepository : IGenericRepository<LicenseKey>
{
    Task<LicenseKey> GetByKeyCode(string keyCode);
}