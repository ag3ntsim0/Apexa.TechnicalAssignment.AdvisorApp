using Apexa.TechnicalAssignment.AdvisorApp.Domain.AdvisorAggregate.ValueObjects;
using System.ComponentModel.DataAnnotations;
using HStatus = Apexa.TechnicalAssignment.AdvisorApp.Domain.AdvisorAggregate.ValueObjects;

namespace Apexa.TechnicalAssignment.AdvisorApp.Domain.AdvisorAggregate;

public class AdvisorAggregate
{

    public required Guid ID { get; set; }


    /// <summary>
    /// could be the ID of the aggregate , 
    /// but since it MUST be hidden , 
    /// then for simplicity i have created a new ID  <see cref="ID"/>
    /// </summary>
    [Required]
    [RegularExpression(@"^\d{9}$")]
    public required string SIN { get; set; }


    [Required]
    [MaxLength(255)]
    public required string Name { get; set; }


    [MaxLength(255)]
    public string? Address { get; set; }

    [RegularExpression(@"^\d{8}$")]
    public string? Phone { get; set; }

    public required HealthStatus? HealthStatus { get; set; }


    public static HealthStatus GenerateRandomHealthStatus()
    {
        var random = new Random();

        int randomNumber = random.Next(100);

        return randomNumber switch
        {
            < 60 => HStatus.HealthStatus.Green,
            < 80 => HStatus.HealthStatus.Yellow,
            _ => HStatus.HealthStatus.Red
        };
    }

}
