using Entity = Apexa.TechnicalAssignment.AdvisorApp.Domain.AdvisorAggregate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apexa.TechnicalAssignment.AdvisorApp.UnitTests.Domain.AdvisorAggregate;

public partial class AdvisorConstructor
{



    [Fact]
    public void InitializesName_LengthTestCase()
    {
        //arrange

        var nameAdvisor = "Lorem ipsum dolor sit amet, consectetur adipiscing elit." +
                " Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua." +
                " Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris " +
                "nisi ut aliquip exdsdfe ea commodo consequat. Duis aute irure dolor.";
        Entity.AdvisorAggregate testAdvisor;


        //act

        testAdvisor = new Entity.AdvisorAggregate
        {
            Address = "aaad",
            HealthStatus = Entity.AdvisorAggregate.GenerateRandomHealthStatus(),
            ID = Guid.NewGuid(),
            Name = nameAdvisor,
            SIN = "123456789",
            Phone = "123456678"
        };


        //assert


        var context = new ValidationContext(testAdvisor) { MemberName = nameof(testAdvisor.Name) };
        var results = new List<ValidationResult>();
        var valid = Validator.TryValidateProperty(testAdvisor.Name, context, results);


        // Ensure the validation failed
        Assert.False(valid);

        // Ensure only one validation result is present
        Assert.Single(results);

        // Ensure that result is from the MaxLengthAttribute
        var maxLengthError = results.First();
        Assert.Contains("maximum length", maxLengthError.ErrorMessage);


    }









    [Fact]
    public void InitializesAddress_LengthTestCase()
    {
        //arrange

        var addressAdvisor = "Lorem ipsum dolor sit amet, consectetur adipiscing elit." +
                " Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua." +
                " Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris " +
                "nisi ut aliquip exdsdfe ea commodo consequat. Duis aute irure dolor.";
        Entity.AdvisorAggregate testAdvisor;


        //act

        testAdvisor = new Entity.AdvisorAggregate
        {
            Address = addressAdvisor,
            HealthStatus = Entity.AdvisorAggregate.GenerateRandomHealthStatus(),
            ID = Guid.NewGuid(),
            Name = "name1",
            SIN = "123456789",
            Phone = "123456678"
        };


        //assert


        var context = new ValidationContext(testAdvisor) { MemberName = nameof(testAdvisor.Address) };
        var results = new List<ValidationResult>();
        var valid = Validator.TryValidateProperty(testAdvisor.Address, context, results);


        // Ensure the validation failed
        Assert.False(valid);

        // Ensure only one validation result is present
        Assert.Single(results);

        // Ensure that result is from the MaxLengthAttribute
        var maxLengthError = results.First();
        Assert.Contains("maximum length", maxLengthError.ErrorMessage);


    }






    [Fact]
    public void InitializesSIN_LengthTestCase()
    {
        //arrange

        var sinAdvisor = "123457891085";
        Entity.AdvisorAggregate testAdvisor;


        //act

        testAdvisor = new Entity.AdvisorAggregate
        {
            Address = "addr",
            HealthStatus = Entity.AdvisorAggregate.GenerateRandomHealthStatus(),
            ID = Guid.NewGuid(),
            Name = "name1",
            SIN = sinAdvisor,
            Phone = "123456678"
        };


        //assert


        var context = new ValidationContext(testAdvisor) { MemberName = nameof(testAdvisor.SIN) };
        var results = new List<ValidationResult>();
        var valid = Validator.TryValidateProperty(testAdvisor.SIN, context, results);


        // Ensure the validation failed
        Assert.False(valid);

        // Ensure only one validation result is present
        Assert.Single(results);

        // Ensure that result is from the RegularExpressionAttribute
        var maxLengthError = results.First();
        Assert.Contains("must match the regular expression", maxLengthError.ErrorMessage);


    }






    [Fact]
    public void InitializesPhone_LengthTestCase()
    {
        //arrange

        var phoneAdvisor = "123454679884562";
        Entity.AdvisorAggregate testAdvisor;


        //act

        testAdvisor = new Entity.AdvisorAggregate
        {
            Address = "addr",
            HealthStatus = Entity.AdvisorAggregate.GenerateRandomHealthStatus(),
            ID = Guid.NewGuid(),
            Name = "name1",
            SIN = "123456789",
            Phone = phoneAdvisor
        };


        //assert


        var context = new ValidationContext(testAdvisor) { MemberName = nameof(testAdvisor.Phone) };
        var results = new List<ValidationResult>();
        var valid = Validator.TryValidateProperty(testAdvisor.Phone, context, results);


        // Ensure the validation failed
        Assert.False(valid);

        // Ensure only one validation result is present
        Assert.Single(results);

        // Ensure that result is from the RegularExpressionAttribute
        var maxLengthError = results.First();
        Assert.Contains("must match the regular expression", maxLengthError.ErrorMessage);


    }



}
