using Apexa.TechnicalAssignment.AdvisorApp.Domain.AdvisorAggregate.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Apexa.TechnicalAssignment.AdvisorApp.Application.Advisors.Commands.DeleteAdvisor;
using Apexa.TechnicalAssignment.AdvisorApp.Application.Advisors.Commands.CreateAdvisor;
using Apexa.TechnicalAssignment.AdvisorApp.Domain.AdvisorAggregate.ValueObjects;
using Apexa.TechnicalAssignment.AdvisorApp.Domain.AdvisorAggregate;
using Apexa.TechnicalAssignment.AdvisorApp.Application.Advisors.Queries;


namespace Apexa.TechnicalAssignment.AdvisorApp.UnitTests.Application.Advisor;

public class DeleteAdvisorsTests
{
    private readonly Mock<ILogger<DeleteAdvisorCommandHandler>> _loggerDel;
    private readonly Mock<ILogger<CreateAdvisorCommandHandler>> _loggerCreate;
    private readonly IMapper _mapper;
    private readonly Mock<IAdvisorRepository> _mockAdvisorRepository;

    public DeleteAdvisorsTests()
    {
        _loggerDel = new Mock<ILogger<DeleteAdvisorCommandHandler>>();
        _mockAdvisorRepository = new Mock<IAdvisorRepository>();

        _loggerCreate = new Mock<ILogger<CreateAdvisorCommandHandler>>();
        var configurationProvider = new MapperConfiguration(
            x => {
                x.CreateMap<CreateAdvisorDTO, AdvisorAggregate>();
                x.CreateMap<AdvisorAggregate, AdvisorDetailsDTO>();
            }

            );
        _mapper = configurationProvider.CreateMapper();
    }


    [Fact]
    public async Task Handle_ValidAdvisor_Deleted()
    {
        //arrange
        var advisorID = await this.CreateAdvisorArrange();


        var handler = new DeleteAdvisorCommandHandler(_loggerDel.Object,  _mockAdvisorRepository.Object);

        //Act
        var deletedRecord=await handler.Handle(new DeleteAdvisorCommand(advisorID), CancellationToken.None);


        // Assert
        Assert.Equal(1 , deletedRecord);

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
        _mockAdvisorRepository.Setup(r => r.DeleteAsync(advisorExpected)).ReturnsAsync(1);


        //Act

        var handler = new CreateAdvisorCommandHandler(_loggerCreate.Object, _mapper, _mockAdvisorRepository.Object);
        var advisorResult= await handler.Handle(new CreateAdvisorCommand(advisor), CancellationToken.None);
        return advisorResult.ID;


    }

}
