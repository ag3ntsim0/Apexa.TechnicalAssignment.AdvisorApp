using Apexa.TechnicalAssignment.AdvisorApp.Domain.AdvisorAggregate.Interfaces;
using Apexa.TechnicalAssignment.AdvisorApp.Domain.AdvisorAggregate.ValueObjects;
using Apexa.TechnicalAssignment.AdvisorApp.Domain.AdvisorAggregate;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Apexa.TechnicalAssignment.AdvisorApp.Application.Advisors.Queries;
using Apexa.TechnicalAssignment.AdvisorApp.Application.Advisors.Queries.GetAdvisorByID;

namespace Apexa.TechnicalAssignment.AdvisorApp.UnitTests.Application.Advisor;

public class GetByIDAdvisorsTests
{
    private readonly Mock<ILogger<GetAdvisorQueryHandler>> _logger;
    private readonly IMapper _mapper;
    private readonly Mock<IAdvisorRepository> _mockAdvisorRepository;

    public GetByIDAdvisorsTests()
    {
        _logger = new Mock<ILogger<GetAdvisorQueryHandler>>();
        _mockAdvisorRepository = new Mock<IAdvisorRepository>();
        var configurationProvider = new MapperConfiguration(
            x =>
                x.CreateMap<AdvisorAggregate, AdvisorDetailsDTO>()
            );
        _mapper = configurationProvider.CreateMapper();

    }


    [Fact]
    public async Task Handle_ValidAdvisor_GetByID()
    {
        //arrange
        var advisor = new AdvisorAggregate
        {
            ID = new Guid("e4dcba99-b28e-4e58-bbf9-fe007aab2484"),
            Name = "Test Advisor1",
            Address = "Test Address1",
            HealthStatus = HealthStatus.Yellow,
            SIN = "123456789",
            Phone = "12345678"

        };

        var advisorExpected = new AdvisorDetailsDTO
        {
            ID = new Guid("e4dcba99-b28e-4e58-bbf9-fe007aab2484"),
            Name = "Test Advisor1",
            Address = "Test Address1",
            HealthStatus = HealthStatus.Yellow

        };

        _mockAdvisorRepository.Setup(r => r.GetByIdAsync(advisor.ID)).ReturnsAsync(advisor);


        //Act
        var handler = new GetAdvisorQueryHandler(_logger.Object, _mapper , _mockAdvisorRepository.Object);
        var advisorResult=await handler.Handle(new GetAdvisorQuery(advisor.ID), CancellationToken.None);


        //assert
        Assert.NotNull(advisorResult);
        Assert.Equal(advisorExpected.ID, advisorResult.ID);
        Assert.Equal(advisorExpected.Name, advisorResult.Name);
        Assert.Equal(advisorExpected.Address, advisorResult.Address);
        Assert.Equal(advisorExpected.HealthStatus, advisorResult.HealthStatus);



    }
}
