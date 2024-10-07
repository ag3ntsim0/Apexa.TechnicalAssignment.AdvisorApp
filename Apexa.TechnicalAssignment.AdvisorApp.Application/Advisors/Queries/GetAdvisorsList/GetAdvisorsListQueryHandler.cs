using Apexa.TechnicalAssignment.AdvisorApp.Domain.AdvisorAggregate.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Apexa.TechnicalAssignment.AdvisorApp.Application.Advisors.Queries.GetAdvisorsList;

public class GetAdvisorsListQueryHandler : IRequestHandler<GetAdvisorsListQuery,  List<AdvisorDetailsDTO>>
{
    private readonly ILogger<GetAdvisorsListQueryHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IAdvisorRepository _advisorRepository;

    public GetAdvisorsListQueryHandler(ILogger<GetAdvisorsListQueryHandler> logger, IMapper mapper, IAdvisorRepository advisorRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _advisorRepository = advisorRepository;
    }
    public async Task<List<AdvisorDetailsDTO>> Handle(GetAdvisorsListQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting All Advisors... ");

        var advisorsList=await _advisorRepository.GetAdvisorsAsync(request.PageIndex, request.PageSize);

        return _mapper.Map<List<AdvisorDetailsDTO>>(advisorsList);

    }
}
