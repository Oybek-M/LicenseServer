using LicenseServer.Domain.Enums;

namespace LicenseServer.Domain.Entities;

public class LicenseKey : Base
{
    public string KeyCode { get; set; } = "";
    public bool IsActive { get;set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime UpdatedDate { get; set;} = DateTime.Now;
    public DateTime ExpiredDate { get; set; } = DateTime.Now;
    public int SessionLimit { get; set; }
    public int CurrentSessions { get; set; }
    public string Description { get; set; }
    public LicenseType LicenseType { get; set; }
}
