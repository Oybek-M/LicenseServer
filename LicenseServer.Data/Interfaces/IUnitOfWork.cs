namespace LicenseServer.Data.Interfaces;

public interface IUnitOfWork
{
    ILicenseKeyRepository LicenseKey { get; }
}
