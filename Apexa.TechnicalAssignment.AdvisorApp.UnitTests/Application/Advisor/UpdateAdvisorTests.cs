using Apexa.TechnicalAssignment.AdvisorApp.Domain.AdvisorAggregate.Interfaces;
using Apexa.TechnicalAssignment.AdvisorApp.Domain.AdvisorAggregate;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Apexa.TechnicalAssignment.AdvisorApp.Application.Advisors.Commands.UpdateAdvisor;
using Apexa.TechnicalAssignment.AdvisorApp.Application.Advisors.Commands.CreateAdvisor;
using Apexa.TechnicalAssignment.AdvisorApp.Domain.AdvisorAggregate.ValueObjects;
using Apexa.TechnicalAssignment.AdvisorApp.Application.Advisors.Queries;

namespace Apexa.TechnicalAssignment.AdvisorApp.UnitTests.Application.Advisor;

public class UpdateAdvisorTests
{
    private readonly Mock<ILogger<UpdateAdvisorCommandHandler>> _loggerUpdt;
    private readonly Mock<ILogger<CreateAdvisorCommandHandler>> _loggerCreate;
    private readonly IMapper _mapper;
    private readonly Mock<IAdvisorRepository> _mockAdvisorRepository;

    public UpdateAdvisorTests()
    {
        _loggerUpdt = new Mock<ILogger<UpdateAdvisorCommandHandler>>();
        _loggerCreate = new Mock<ILogger<CreateAdvisorCommandHandler>>();

        _mockAdvisorRepository = new Mock<IAdvisorRepository>();
        var configurationProvider = new MapperConfiguration(
            x => {
                x.CreateMap<CreateAdvisorDTO, AdvisorAggregate>();
                x.CreateMap<UpdateAdvisorDTO, AdvisorAggregate>()
                    .ReverseMap();
                x.CreateMap<AdvisorAggregate, AdvisorDetailsDTO>();


            }

            ); 
        _mapper = configurationProvider.CreateMapper();

    }


    [Fact]
    public async Task Handle_ValidAdvisor_Updated()
    {
        //arrange
        var advisorID = await this.CreateAdvisorArrange();

        
        var advisorUpdate = new UpdateAdvisorDTO
        {
            ID = advisorID,
            Name = "Test Advisor2",
            Address = "TEST Address",

        };
        _mockAdvisorRepository.Setup(r => r.UpdateAsync(It.Is<AdvisorAggregate>(x=>x.ID== advisorID))).ReturnsAsync(1);


        var handler = new UpdateAdvisorCommandHandler(_loggerUpdt.Object, _mapper, _mockAdvisorRepository.Object);


        //Act
        var updatedRecord = await handler.Handle(new UpdateAdvisorCommand(advisorUpdate), CancellationToken.None);


        // Assert
        Assert.Equal(1, updatedRecord);

    }


    private async Task<Guid> CreateAdvisorArrange()
    {
        //arrange
        AdvisorAggregate advisorMock = null;

        var advisor = new CreateAdvisorDTO
        {
            Name = "Test Advisor1",
            Address = "Test Address1",
            SIN = "123456789",
            Phone = "12345678"
        };

        var advisorExpected = new AdvisorAggregate
        {
            ID = new Guid("14ddef99-b28e-4e58-bbf9-fe007aab2461"),
            Name = "Test Advisor1",
            Address = "Test Address1",
            HealthStatus = HealthStatus.Yellow,
            SIN = "123456789",
            Phone = "12345678"

        };



        _mockAdvisorRepository.Setup(r => r.GetBySINAsync(advisor.SIN)).ReturnsAsync(advisorMock);
        _mockAdvisorRepository.Setup(r => r.AddAsync(It.IsAny<AdvisorAggregate>())).ReturnsAsync(1);
        _mockAdvisorRepository.Setup(r => r.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(advisorExpected);


        //Act

        var handler = new CreateAdvisorCommandHandler(_loggerCreate.Object, _mapper, _mockAdvisorRepository.Object);
        var advisorResult = await handler.Handle(new CreateAdvisorCommand(advisor), CancellationToken.None);
        return advisorResult.ID;

    }
}
