using Apexa.TechnicalAssignment.AdvisorApp.Domain.AdvisorAggregate.Interfaces;
using Apexa.TechnicalAssignment.AdvisorApp.Domain.AdvisorAggregate;
using Apexa.TechnicalAssignment.AdvisorApp.Domain.AdvisorAggregate.Exceptions;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;


namespace Apexa.TechnicalAssignment.AdvisorApp.Application.Advisors.Commands.UpdateAdvisor
{
    public class UpdateAdvisorCommandHandler : IRequestHandler<UpdateAdvisorCommand,int>
    {
        private readonly ILogger<UpdateAdvisorCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IAdvisorRepository _advisorRepository;

        public UpdateAdvisorCommandHandler(ILogger<UpdateAdvisorCommandHandler> logger,IMapper mapper, IAdvisorRepository advisorRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _advisorRepository = advisorRepository;
        }
        public async Task<int> Handle(UpdateAdvisorCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Started updating Advisor with ID : {ID} by validating ...", request.Advisor.ID);

            if (request.Advisor.ID == Guid.Empty )
                throw new AdvisorValidationException($"Advisor with ID {request.Advisor.ID} format is not valide");


            Validator.ValidateObject(request.Advisor, new ValidationContext(request.Advisor), true);


            _logger.LogInformation("getting Advisor with ID : {ID} and binding Sensitive Data...", request.Advisor.ID);

            var advisorFullData =await _advisorRepository.GetByIdAsync(request.Advisor.ID);

            if (advisorFullData == null)
            {
                _logger.LogWarning("Advisor with ID : {ID} not found.", request.Advisor.ID);

                throw new AdvisorNotFoundException(request.Advisor.ID);
            }

            var advisorToUpdate = _mapper.Map<AdvisorAggregate>(request.Advisor);
            //rebind missed data dto to the entity
            advisorToUpdate.SIN= advisorFullData.SIN;
            advisorToUpdate.Phone = advisorFullData.Phone;
            advisorToUpdate.HealthStatus = advisorFullData.HealthStatus;


            _logger.LogInformation("Updating Advisor with SIN : {SIN}", advisorToUpdate.SIN);

            return await _advisorRepository.UpdateAsync(advisorToUpdate);
        }
    }
}
