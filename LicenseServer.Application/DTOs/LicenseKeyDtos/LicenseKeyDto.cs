using LicenseServer.Domain.Entities;
using LicenseServer.Domain.Enums;

namespace LicenseServer.Application.DTOs.LicenseKeyDtos;

public class LicenseKeyDto : AddLicenseKeyDto
{
    public int Id { get; set; }
    public string KeyCode { get; set; } = "";
    public bool IsActive { get; set; } = true;
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
    public int CurrentSessions { get; set; }


    public static implicit operator LicenseKeyDto(LicenseKey licenseKey)
    {
        return new LicenseKeyDto()
        {
            Id = licenseKey.Id,
            KeyCode = licenseKey.KeyCode,
            IsActive = licenseKey.IsActive,
            CreatedDate = licenseKey.CreatedDate,
            UpdatedDate = licenseKey.UpdatedDate,
            ExpiredDate = licenseKey.ExpiredDate,
            SessionLimit = licenseKey.SessionLimit,
            CurrentSessions = licenseKey.CurrentSessions,
            Description = licenseKey.Description,
            LicenseType = licenseKey.LicenseType
        };
    }
}
