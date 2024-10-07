using System.ComponentModel.Design;
using Apexa.TechnicalAssignment.AdvisorApp.Domain.Common.Exceptions;

namespace Apexa.TechnicalAssignment.AdvisorApp.Domain.AdvisorAggregate.Exceptions
{
    public class AdvisorValidationException : ValidationException
    {
        public AdvisorValidationException(string message) :
            base(message)
        {
        }
    }
}
