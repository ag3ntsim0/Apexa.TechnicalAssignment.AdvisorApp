using Apexa.TechnicalAssignment.AdvisorApp.Domain.AdvisorAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apexa.TechnicalAssignment.AdvisorApp.Application.Advisors.Queries
{
    public class AdvisorDetailsDTO
    {
        [Required]
        public Guid ID { get; set; }

        [Required]
        [MaxLength(255)]
        public required string Name { get; set; }

        [MaxLength(255)]
        public string? Address { get; set; }

        public required HealthStatus HealthStatus { get; set; }
    }
}
