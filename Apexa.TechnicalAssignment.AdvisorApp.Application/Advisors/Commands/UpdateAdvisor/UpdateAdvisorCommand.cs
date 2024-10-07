using MediatR;

namespace Apexa.TechnicalAssignment.AdvisorApp.Application.Advisors.Commands.UpdateAdvisor;

public record UpdateAdvisorCommand(UpdateAdvisorDTO Advisor) : IRequest<int>
{
    
}
