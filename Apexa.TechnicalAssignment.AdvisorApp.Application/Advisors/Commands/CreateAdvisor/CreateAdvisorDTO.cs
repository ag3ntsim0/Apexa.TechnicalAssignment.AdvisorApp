using Apexa.TechnicalAssignment.AdvisorApp.Domain.AdvisorAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apexa.TechnicalAssignment.AdvisorApp.Application.Advisors.Commands.CreateAdvisor
{
    public class CreateAdvisorDTO
    {
        [Required]
        [MaxLength(255)]
        public required string Name { get; set; }

        [MaxLength(255)]
        public string? Address { get; set; }


        [Required]
        [RegularExpression(@"^\d{9}$")]
        public required string SIN { get; set; }


        [RegularExpression(@"^\d{8}$")]
        public string? Phone { get; set; }
    }
}
