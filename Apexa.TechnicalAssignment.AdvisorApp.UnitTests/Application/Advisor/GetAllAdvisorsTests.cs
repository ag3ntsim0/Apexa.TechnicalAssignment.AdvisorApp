using Apexa.TechnicalAssignment.AdvisorApp.Domain.AdvisorAggregate.Interfaces;
using Apexa.TechnicalAssignment.AdvisorApp.Domain.AdvisorAggregate.ValueObjects;
using Apexa.TechnicalAssignment.AdvisorApp.Domain.AdvisorAggregate;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Apexa.TechnicalAssignment.AdvisorApp.Application.Advisors.Queries.GetAdvisorsList;
using Apexa.TechnicalAssignment.AdvisorApp.Application.Advisors.Queries;

namespace Apexa.TechnicalAssignment.AdvisorApp.UnitTests.Application.Advisor;

public class GetAllAdvisorsTests
{
    private readonly Mock<ILogger<GetAdvisorsListQueryHandler>> _logger;
    private readonly IMapper _mapper;
    private readonly Mock<IAdvisorRepository> _mockAdvisorRepository;

    public GetAllAdvisorsTests()
    {
        _logger = new Mock<ILogger<GetAdvisorsListQueryHandler>>();
        _mockAdvisorRepository = new Mock<IAdvisorRepository>();
        var configurationProvider = new MapperConfiguration(
            x =>
                x.CreateMap< AdvisorAggregate, AdvisorDetailsDTO>()
            );
        _mapper = configurationProvider.CreateMapper();

    }


    [Fact]
    public async Task Handle_ValidAdvisor_GetAll()
    {
        //arrange
        var advisorList = new List<AdvisorAggregate>()
        {
            new AdvisorAggregate
            {
                ID =new Guid("e4dcba99-b28e-4e58-bbf9-fe007aab2484"),
                Name="Test Advisor1",
                Address = "Test Address1",
                HealthStatus = HealthStatus.Yellow,
                SIN = "123456789",
                Phone = "12345678",

            },
            new AdvisorAggregate
            {
                ID =new Guid("14ddef99-b28e-4e58-bbf9-fe007aab2461"),
                Name="Test Advisor2",
                Address = "Test Address2",
                HealthStatus = HealthStatus.Green,
                SIN = "123451230",
                Phone = "12345123",

            },
        };


        _mockAdvisorRepository.Setup(r => r.GetAdvisorsAsync(1, 10)).ReturnsAsync(advisorList);


        //Act
        var handler = new GetAdvisorsListQueryHandler(_logger.Object, _mapper, _mockAdvisorRepository.Object);
        var allAdvisors=await handler.Handle(new GetAdvisorsListQuery(1,10), CancellationToken.None);


        //assert
        Assert.NotNull(allAdvisors);
        Assert.Equal(2, allAdvisors.Count);

    }
}
