using System.Net;

namespace LicenseServer.Application.Common.Exceptions;

public class ValidatorException : StatusCodeException
{
    public ValidatorException(string message) : base(HttpStatusCode.BadRequest, message) { }
}
