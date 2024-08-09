using LicenseServer.Data.DbContexts;
using LicenseServer.Data.Interfaces;
using LicenseServer.Domain.Entities;

namespace LicenseServer.Data.Repositores;

public class LicenseKeyRepository(AppDbContext dbContext) : GenericRepository<LicenseKey>(dbContext), ILicenseKeyRepository
{
    public Task<LicenseKey> GetByKeyCode(string code)
    {
        throw new NotImplementedException();
    }
}
