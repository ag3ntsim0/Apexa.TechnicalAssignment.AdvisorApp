using Apexa.TechnicalAssignment.AdvisorApp.Application.Advisors.Queries;
using MediatR;

namespace Apexa.TechnicalAssignment.AdvisorApp.Application.Advisors.Commands.CreateAdvisor;

public record CreateAdvisorCommand(CreateAdvisorDTO Advisor) : IRequest<AdvisorDetailsDTO>
{
  

}

