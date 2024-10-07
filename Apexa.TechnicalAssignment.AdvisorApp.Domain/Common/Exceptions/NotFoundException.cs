namespace Apexa.TechnicalAssignment.AdvisorApp.Domain.Common.Exceptions;

public abstract class NotFoundException : NullReferenceException
{
    protected NotFoundException(string message) : base(message)
    {

    }
}
