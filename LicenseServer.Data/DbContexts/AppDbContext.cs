using LicenseServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LicenseServer.Data.DbContexts;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<LicenseKey> LicenseKeys { get; set; }
}
