using Apexa.TechnicalAssignment.AdvisorApp.Application.Advisors.Commands.CreateAdvisor;
using Apexa.TechnicalAssignment.AdvisorApp.Application.Advisors.Commands.UpdateAdvisor;
using Apexa.TechnicalAssignment.AdvisorApp.Application.Advisors.Queries;
using Apexa.TechnicalAssignment.AdvisorApp.Domain.AdvisorAggregate;
using Apexa.TechnicalAssignment.AdvisorApp.Domain.AdvisorAggregate.Interfaces;
using Apexa.TechnicalAssignment.AdvisorApp.Domain.AdvisorAggregate.ValueObjects;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using System.Net.WebSockets;


namespace Apexa.TechnicalAssignment.AdvisorApp.UnitTests.Application.Advisor;

public class CreateAdvisorTests
{
    private readonly Mock<ILogger<CreateAdvisorCommandHandler>> _logger;
    private readonly IMapper _mapper;
    private readonly Mock<IAdvisorRepository> _mockAdvisorRepository;


    public CreateAdvisorTests()
    {
        _logger = new Mock<ILogger<CreateAdvisorCommandHandler>>();
        _mockAdvisorRepository = new Mock<IAdvisorRepository>();
        var configurationProvider = new MapperConfiguration(
            x =>
            {

                x.CreateMap<CreateAdvisorDTO, AdvisorAggregate>()
                    .ReverseMap();
                x.CreateMap<AdvisorAggregate, AdvisorDetailsDTO>();


            }
            );
        _mapper = configurationProvider.CreateMapper();

    }


    [Fact]
    public async Task Handle_ValidAdvisor_Added()
    {
        //arrange
        AdvisorAggregate advisorMock=null;
        
        var advisor = new CreateAdvisorDTO
        {
            Name = "Test Advisor1",
            Address = "Test Address1",
            SIN = "123456789",
            Phone = "12345678"
        };

        var advisorExpected = new AdvisorAggregate
        {
            ID = new Guid("e4dcba99-b28e-4e58-bbf9-fe007aab2484"),
            Name = "Test Advisor1",
            Address = "Test Address1",
            HealthStatus = HealthStatus.Yellow,
            SIN = "123456789",
            Phone = "12345678"

        };



        _mockAdvisorRepository.Setup(r => r.GetBySINAsync(advisor.SIN)).ReturnsAsync(advisorMock);
        _mockAdvisorRepository.Setup(r => r.AddAsync(It.IsAny<AdvisorAggregate>())).ReturnsAsync(1);

        //Act

        var handler = new CreateAdvisorCommandHandler(_logger.Object, _mapper, _mockAdvisorRepository.Object);
        var advisorResult=await handler.Handle(new CreateAdvisorCommand(advisor), CancellationToken.None);

        //Assert

        Assert.NotNull(advisorResult);
        Assert.True(Guid.Empty!= advisorResult.ID);


    }
}
