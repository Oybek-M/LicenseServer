using LicenseServer.Data.DbContexts;
using LicenseServer.Data.Interfaces;
using LicenseServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LicenseServer.Data.Repositores;

public class GenericRepository<T>(AppDbContext dbContext)
    : IGenericRepository<T> where T : Base
{
    protected readonly AppDbContext _dbContext = dbContext;
    private readonly DbSet<T> _dbSet = dbContext.Set<T>();


    public async Task<byte> CreateAsync(T entity)
    {
        try
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return 0;
        }
        catch (Exception ex)
        {
            // Error-proofing
            Console.WriteLine(ex.Message);
            // If unsuccessful, return 1 as error
            return 1;
        }
    }

    public async Task<List<T>> GetAllAsync()
    {
        try
        {
            var licenseKeys = await _dbSet.ToListAsync();
            // If successful, return response
            return licenseKeys; 
        }
        catch (Exception ex)
        {
            // Error-proofing
            Console.WriteLine(ex.Message);
            // If unsuccessful, return empty list as response
            return new List<T>(); 
        }
    }

    public async Task<T> GetByIdAsync(int id)
    {
        try
        {
            var licenseKey = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
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

    public async Task<byte> UpdateAsync(T entity)
    {
        try
        {
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
            // If successful, return 0 as response
            return 0;
        } catch (Exception ex)
        {
            // Error-proofing
            Console.WriteLine(ex.Message);
            // If unsuccessful, return 1 as error
            return 1;
        }
    }

    public async Task<byte> DeleteAsync(T entity)
    {
        try
        {
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
            // If successful, return 0 as response
            return 0;
        } catch (Exception ex)
        {
            // Error-proofing
            Console.WriteLine(ex.Message);
            // If unsuccessful, return 1 as error
            return 1;
        }
    }
}
