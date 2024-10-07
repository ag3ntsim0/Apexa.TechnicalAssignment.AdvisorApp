using Apexa.TechnicalAssignment.AdvisorApp.Domain.Common.Exceptions;

namespace Apexa.TechnicalAssignment.AdvisorApp.Domain.AdvisorAggregate.Exceptions;

public class AdvisorNotFoundException : NotFoundException
{
    public AdvisorNotFoundException(Guid AdvisorID) :
        base($"The Advisor with ID: {AdvisorID} doesn't exist.")
    {
    }
}
