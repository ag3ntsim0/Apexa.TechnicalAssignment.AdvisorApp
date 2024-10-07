using Entity=Apexa.TechnicalAssignment.AdvisorApp.Domain.AdvisorAggregate;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace Apexa.TechnicalAssignment.AdvisorApp.UnitTests.Domain.AdvisorAggregate;

public partial class AdvisorConstructor
{


    [Fact]
    public void HealthStatus_GenerationProbabilityTest()
    {
        // Arrange
        var iterations = 100000; // Number of times to generate random health status
        var greenCount = 0;
        var yellowCount = 0;
        var redCount = 0;

        // Act
        for (int i = 0; i < iterations; i++)
        {
            var healthStatus = Entity.AdvisorAggregate.GenerateRandomHealthStatus();
            switch (healthStatus)
            {
                case Entity.ValueObjects.HealthStatus.Green:
                    greenCount++;
                    break;
                case Entity.ValueObjects.HealthStatus.Yellow:
                    yellowCount++;
                    break;
                case Entity.ValueObjects.HealthStatus.Red:
                    redCount++;
                    break;
            }
        }

        // Calculate actual probabilities
        var greenProbability = (double)greenCount / iterations * 100;
        var yellowProbability = (double)yellowCount / iterations * 100;
        var redProbability = (double)redCount / iterations * 100;

        // Assert
        Assert.InRange(greenProbability, 58, 62);  // Allowing a small tolerance
        Assert.InRange(yellowProbability, 18, 22); // Allowing a small tolerance
        Assert.InRange(redProbability, 18, 22);    // Allowing a small tolerance
    }






}
