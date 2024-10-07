using Apexa.TechnicalAssignment.AdvisorApp.Domain.AdvisorAggregate.Interfaces;
using Apexa.TechnicalAssignment.AdvisorApp.Domain.AdvisorAggregate.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;


namespace Apexa.TechnicalAssignment.AdvisorApp.Application.Advisors.Commands.DeleteAdvisor
{
    public class DeleteAdvisorCommandHandler : IRequestHandler<DeleteAdvisorCommand,int>
    {
        private readonly ILogger<DeleteAdvisorCommandHandler> _logger;
        private readonly IAdvisorRepository _advisorRepository;


        public DeleteAdvisorCommandHandler(ILogger<DeleteAdvisorCommandHandler> logger, IAdvisorRepository advisorRepository)
        {
            _logger = logger;
            _advisorRepository = advisorRepository;

        }


        public async Task<int> Handle(DeleteAdvisorCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Started validating DeleteAdvisorCommand ...");

            if (request.ID == Guid.Empty )
                throw new AdvisorValidationException($"Advisor with ID {request.ID} format is not valide");
            

            _logger.LogInformation("Started removing Advisor with ID : {ID}", request.ID);


            var advisor = await _advisorRepository.GetByIdAsync(request.ID);

            if (advisor == null)
            {
                _logger.LogWarning("Advisor with ID : {ID} not found.", request.ID);

                throw new AdvisorNotFoundException(request.ID);
            }
            _logger.LogInformation("Removing Advisor with SIN : {SIN} from DB...", advisor.SIN);

            return await _advisorRepository.DeleteAsync(advisor);


        }
    }
}
