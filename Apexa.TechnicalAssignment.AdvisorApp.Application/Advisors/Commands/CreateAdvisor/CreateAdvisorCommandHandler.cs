using Apexa.TechnicalAssignment.AdvisorApp.Domain.AdvisorAggregate.Interfaces;
using Apexa.TechnicalAssignment.AdvisorApp.Domain.AdvisorAggregate;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using Apexa.TechnicalAssignment.AdvisorApp.Domain.AdvisorAggregate.Exceptions;
using Apexa.TechnicalAssignment.AdvisorApp.Application.Advisors.Queries;

namespace Apexa.TechnicalAssignment.AdvisorApp.Application.Advisors.Commands.CreateAdvisor;

public class CreateAdvisorCommandHandler : IRequestHandler<CreateAdvisorCommand, AdvisorDetailsDTO>
{
    private readonly ILogger<CreateAdvisorCommandHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IAdvisorRepository _advisorRepository;

    public CreateAdvisorCommandHandler(ILogger<CreateAdvisorCommandHandler> logger, IMapper mapper, IAdvisorRepository advisorRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _advisorRepository = advisorRepository;
    }
    public async Task<AdvisorDetailsDTO> Handle(CreateAdvisorCommand request, CancellationToken cancellationToken)
    {


        _logger.LogInformation("Started validating CreateAdvisorCommand ...");


        Validator.ValidateObject(request.Advisor, new ValidationContext(request.Advisor), true);

        var advisor = _mapper.Map<AdvisorAggregate>(request.Advisor);

        //Validating the uniqueness of SIN
        if (await _advisorRepository.GetBySINAsync(advisor.SIN) != null)
            throw new AdvisorDuplicatedSINException($"Advisor SIN {advisor.SIN} already exists !");


        //setting Random Health Status
        advisor.HealthStatus = AdvisorAggregate.GenerateRandomHealthStatus();

        advisor.ID = Guid.NewGuid();

        _logger.LogInformation("Adding new Advisor to DB...");

        var advisoResult = await _advisorRepository.AddAsync(advisor);

        if (advisoResult==1)
            return _mapper.Map<AdvisorDetailsDTO>(advisor);
        else
            throw new Exception($"Advisor SIN {advisor.SIN} did not being persisted !");


    }


}
