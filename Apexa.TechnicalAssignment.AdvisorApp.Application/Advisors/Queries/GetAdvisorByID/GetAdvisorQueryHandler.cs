using Apexa.TechnicalAssignment.AdvisorApp.Domain.AdvisorAggregate.Interfaces;
using Apexa.TechnicalAssignment.AdvisorApp.Domain.AdvisorAggregate.Exceptions;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Apexa.TechnicalAssignment.AdvisorApp.Application.Advisors.Queries.GetAdvisorByID;

public class GetAdvisorQueryHandler : IRequestHandler<GetAdvisorQuery, AdvisorDetailsDTO>
{
    private readonly ILogger<GetAdvisorQueryHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IAdvisorRepository _advisorRepository;
    public GetAdvisorQueryHandler(ILogger<GetAdvisorQueryHandler> logger, IMapper mapper, IAdvisorRepository advisorRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _advisorRepository = advisorRepository;
    }
    public async Task<AdvisorDetailsDTO> Handle(GetAdvisorQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting validating GetAdvisorQueryHandler ...");

        if (request.ID == Guid.Empty)
            throw new AdvisorValidationException($"Advisor with ID {request.ID} format is not valide");

        _logger.LogInformation("Getting Advisor with Id : {Id}", request.ID);

        var advisor = await _advisorRepository.GetByIdAsync(request.ID);

        if (advisor == null)
        {
            _logger.LogWarning("Advisor with Id : {Id} not found.", request.ID);

            throw new AdvisorNotFoundException(request.ID);
        }

        return _mapper.Map<AdvisorDetailsDTO>(advisor);

    }
}
