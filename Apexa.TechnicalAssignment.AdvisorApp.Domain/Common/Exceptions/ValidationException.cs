namespace Apexa.TechnicalAssignment.AdvisorApp.Domain.Common.Exceptions;

public class ValidationException : ArgumentOutOfRangeException
{
    protected ValidationException(string message) : base(message)
    {

    }
}
