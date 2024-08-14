using LicenseServer.Data.DbContexts;
using LicenseServer.Data.Interfaces;
using LicenseServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LicenseServer.Data.Repositores;

public class LicenseKeyRepository(AppDbContext dbContext) : GenericRepository<LicenseKey>(dbContext), ILicenseKeyRepository
{
    private readonly DbSet<LicenseKey> _dbSet = dbContext.Set<LicenseKey>();

    public async Task<LicenseKey> GetByKeyCode(string keyCode)
    {
        try
        {
            var licenseKey = await _dbSet.FirstOrDefaultAsync(x => x.KeyCode == keyCode);
            // If successful, return response
            return licenseKey;
        }
        catch (Exception ex)
        {
            // Error-proofing
            Console.WriteLine(ex.Message);
            // If unsuccessful, return null as response
            return null;
        }
    }
}
