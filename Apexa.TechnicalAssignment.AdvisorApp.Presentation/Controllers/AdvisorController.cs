using Apexa.TechnicalAssignment.AdvisorApp.Application.Advisors.Commands.CreateAdvisor;
using Apexa.TechnicalAssignment.AdvisorApp.Application.Advisors.Commands.DeleteAdvisor;
using Apexa.TechnicalAssignment.AdvisorApp.Application.Advisors.Commands.UpdateAdvisor;
using Apexa.TechnicalAssignment.AdvisorApp.Application.Advisors.Queries;
using Apexa.TechnicalAssignment.AdvisorApp.Application.Advisors.Queries.GetAdvisorByID;
using Apexa.TechnicalAssignment.AdvisorApp.Application.Advisors.Queries.GetAdvisorsList;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Apexa.TechnicalAssignment.AdvisorApp.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdvisorController : ControllerBase
    {

        private readonly ILogger<AdvisorController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AdvisorController(ILogger<AdvisorController> logger, IMediator mediator, IMapper mapper) 
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpGet("{ID:guid}", Name = "GetAdvisorById")]
        public async Task<ActionResult<AdvisorDetailsDTO>> GetAdvisorById(Guid ID)
        {
            _logger.LogInformation("Started getting endpoint for advisor with Id : {Id} . ", ID);

            var query = new GetAdvisorQuery(ID);

            var advisor = await _mediator.Send(query);
            return Ok(advisor);
        }

        [HttpGet("List", Name = "GetAllAdvisors")]
        public async Task<ActionResult<AdvisorDetailsDTO>> GetAllAdvisors(int pageIndex = 1, int pageSize = 10)
        {
            _logger.LogInformation("Started getting all advisors endpoint. ");

            var query = new GetAdvisorsListQuery(pageIndex, pageSize);

            var listAdvisors = await _mediator.Send(query);

            return Ok(listAdvisors);
        }



        [HttpPost(Name = "AddAdvisor")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateAdvisorDTO request)
        {
            _logger.LogInformation("Started Create endpoint. ");

            if (ModelState.IsValid)
            {
                var command = _mapper.Map<CreateAdvisorCommand>(request);

                var id = await _mediator.Send(command);
                return Ok(id);
            }

            return BadRequest(ModelState);
        }

        [HttpPut(Name = "UpdateAdvisor")]
        public async Task<ActionResult> Update([FromBody] UpdateAdvisorDTO request)
        {
            _logger.LogInformation("Started updating endpoint for advisor with Id : {Id} . ", request.ID);

            if (ModelState.IsValid)
            {
                var command = _mapper.Map<UpdateAdvisorCommand>(request);
                if (await _mediator.Send(command) == 1)
                    return Ok(request.ID);
                else
                    return Problem();

            }

            return BadRequest(ModelState);

        }


        [HttpDelete("{ID:guid}", Name = "DeleteAdvisor")]
        public async Task<IActionResult> Delete(Guid ID)
        {
            _logger.LogInformation("Started deleting endpoint for advisor with Id : {ID} . ", ID);

            if (ID == Guid.Empty)
                return BadRequest("invalid id");


            var command = _mapper.Map<DeleteAdvisorCommand>(ID);

            if(await _mediator.Send(command)==1)
                return Ok(ID);
            else
                return Problem();
        }






    }
}
