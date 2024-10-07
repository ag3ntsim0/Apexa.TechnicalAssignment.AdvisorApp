using MediatR;


namespace Apexa.TechnicalAssignment.AdvisorApp.Application.Advisors.Commands.DeleteAdvisor
{
    public record DeleteAdvisorCommand(Guid ID) : IRequest<int>
    {
        
    }
}
