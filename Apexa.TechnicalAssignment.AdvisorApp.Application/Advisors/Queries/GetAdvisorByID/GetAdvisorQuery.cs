using MediatR;

namespace Apexa.TechnicalAssignment.AdvisorApp.Application.Advisors.Queries.GetAdvisorByID;

public record GetAdvisorQuery(Guid ID) : IRequest<AdvisorDetailsDTO>
{
    
}
