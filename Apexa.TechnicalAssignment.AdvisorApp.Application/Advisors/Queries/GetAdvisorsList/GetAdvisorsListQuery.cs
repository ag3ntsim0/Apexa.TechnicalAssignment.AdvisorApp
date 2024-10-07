using MediatR;


namespace Apexa.TechnicalAssignment.AdvisorApp.Application.Advisors.Queries.GetAdvisorsList;

public record GetAdvisorsListQuery(int PageIndex, int PageSize) : IRequest<List<AdvisorDetailsDTO>> 
{
    
}
