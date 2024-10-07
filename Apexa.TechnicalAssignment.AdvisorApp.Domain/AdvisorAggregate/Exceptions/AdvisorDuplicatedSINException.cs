using System.ComponentModel.Design;
using Apexa.TechnicalAssignment.AdvisorApp.Domain.Common.Exceptions;

namespace Apexa.TechnicalAssignment.AdvisorApp.Domain.AdvisorAggregate.Exceptions
{
    public class AdvisorDuplicatedSINException : AdvisorValidationException
    {
        public AdvisorDuplicatedSINException(string message) :
            base(message)
        {
        }
    }
}
