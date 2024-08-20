using System.Runtime.CompilerServices;
using System.Net;

using Microsoft.IdentityModel.Tokens;
using Microsoft.Identity.Client;

using LicenseServer.Application.Common.Exceptions;
using LicenseServer.Application.DTOs.LicenseKeyDtos;
using LicenseServer.Application.Interfaces;
using LicenseServer.Data.Interfaces;
using LicenseServer.Domain.Entities;

using FluentValidation;
using System.Reflection.Metadata.Ecma335;
using LicenseServer.Application.Common.Helper;


namespace LicenseServer.Application.Services;


public class LicenseKeyService(IUnitOfWork unitOfWork,
                               IValidator<LicenseKey> validator)
    : ILicenseKeyService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IValidator<LicenseKey> _validator = validator;

    public async Task<bool> CreateAsync(AddLicenseKeyDto licenseKeyDto, int count)
    {
        if (count >= 1 && count <= 100)
        {
            var result = await _validator.ValidateAsync(licenseKeyDto);

            if(result.IsValid)
            {
                for (int i = 0; i <= count; i++)
                {
                    try
                    {
                        await _unitOfWork.LicenseKey.CreateAsync(licenseKeyDto);
                    }
                    catch (Exception ex)
                    {
                        return false;
                        throw new StatusCodeException(HttpStatusCode.BadGateway, ex.Message);
                    }
                }

                return true;
                throw new StatusCodeException(HttpStatusCode.Created, "Muvaffaqiyatli yaratildi");
            } else
            {
                return false;
                throw new ValidatorException("Ma'lumotlar to'g'ri kiritilmagan");
            }
        }
        else
        {
            return false;
            throw new StatusCodeException(HttpStatusCode.BadRequest, "Bir urinish bilan 100 dan ortiq yaratib bo'lmaydi");
        }
    }

    public async Task<List<LicenseKeyDto>> GetAllAsync()
    {
        try
        {
            var licenseKeys = await _unitOfWork.LicenseKey.GetAllAsync();
            var licenseKeyModel = licenseKeys.Select(item => (LicenseKeyDto)item).ToList();

            return licenseKeyModel;
        }
        catch (Exception ex)
        {
            return new List<LicenseKeyDto>();
            throw new StatusCodeException(HttpStatusCode.NotFound, ex.Message);
        }
    }

    public async Task<LicenseKeyDto> GetByIdAsync(int id)
    {
        try
        {
            var licensekey = await _unitOfWork.LicenseKey
                                              .GetByIdAsync(id);

            return (LicenseKeyDto)licensekey;
        }
        catch (Exception ex)
        {
            return new LicenseKeyDto();
            throw new StatusCodeException(HttpStatusCode.NotFound, ex.Message);
        }
    }

    public async Task<LicenseKeyDto> GetByKeyCodeAsync(string licenseKeyCode)
    {
        try
        {
            var licenseKey = await _unitOfWork.LicenseKey
                                              .GetByKeyCode(licenseKeyCode);

            return (LicenseKeyDto)licenseKey;
        }
        catch (Exception ex)
        {
            return new LicenseKeyDto();
            throw new StatusCodeException(HttpStatusCode.NotFound, ex.Message);
        }
    }

    public async Task<bool> UpdateAsync(LicenseKeyDto licenseKeyDto)
    {
        var licenseKey = _unitOfWork.LicenseKey.GetByIdAsync(licenseKeyDto.Id);
        if (licenseKey is null)
        {
            return false;
            throw new StatusCodeException(HttpStatusCode.NotFound, "Bunday Litsenziya topilmadi");
        }


        var result = await _validator.ValidateAsync(licenseKeyDto);

        if (!result.IsValid)
        {
            try
            {
                await _unitOfWork.LicenseKey.CreateAsync(licenseKeyDto);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new StatusCodeException(HttpStatusCode.BadGateway, ex.Message);
            }
        }
        else
        {
            return false;
            throw new ValidatorException("Ma'lumotlar to'g'ri kiritilmagan");
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            var licenseKey = await _unitOfWork.LicenseKey.GetByIdAsync(id);
            if (licenseKey is null)
            {
                throw new StatusCodeException(HttpStatusCode.NotFound, "Bunday Litseznsiya topilmadi");
            }

            await _unitOfWork.LicenseKey.DeleteAsync(licenseKey);
            return true;
        }
        catch (Exception ex)
        {
            return false;
            throw new StatusCodeException(HttpStatusCode.NotFound, ex.Message);
        }
    }



    // Security: Check and Generate(Online/Offline)
    public async Task<string> GetKeyCode(int lenght, int count)
    {
        return LicenseKeyHelper.GenerateLicenseKey(lenght, count);
    }

    public Task<(int, string)> CheckKeyCode(string keyCode)
    {
        throw new NotImplementedException();
    }
    // ______________________________
}
