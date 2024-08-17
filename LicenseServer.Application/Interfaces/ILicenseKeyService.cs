using LicenseServer.Application.DTOs.LicenseKeyDtos;

namespace LicenseServer.Application.Interfaces;

public interface ILicenseKeyService
{
    Task<bool> CreateAsync(List<AddLicenseKeyDto> licenseKeysDto);
    Task<List<LicenseKeyDto>> GetAllAsync();
    Task<LicenseKeyDto> GetByIdAsync(int id);
    Task<LicenseKeyDto> GetByKeyCodeAsync(string licenseKeyCode);
    Task<bool> UpdateAsync(LicenseKeyDto licenseKeyDto);
    Task<bool> DeleteAsync(int id);

    Task<(byte, string)> CheckKeyCode(string keyCode);
}
