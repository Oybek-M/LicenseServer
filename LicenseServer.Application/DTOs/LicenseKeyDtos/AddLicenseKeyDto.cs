using LicenseServer.Domain.Entities;
using LicenseServer.Domain.Enums;

namespace LicenseServer.Application.DTOs.LicenseKeyDtos;

public class AddLicenseKeyDto
{
    public DateTime ExpiredDate { get; set; } = DateTime.UtcNow;
    public int SessionLimit { get; set; } = 1;
    public string Description { get; set; } = string.Empty;
    public LicenseType LicenseType { get; set; } = LicenseType.Online;


    public static implicit operator LicenseKey(AddLicenseKeyDto dto)
    {
        return new LicenseKey
        {
            ExpiredDate = dto.ExpiredDate,
            SessionLimit = dto.SessionLimit,
            Description = dto.Description,
            LicenseType = dto.LicenseType
        };
    }
}
