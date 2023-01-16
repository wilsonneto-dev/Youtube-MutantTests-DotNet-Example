using FluentAssertions;
using CoreEntity = TheApp.Core.Person;

namespace TheApp.UnitTests.Core.Person;

public class PersonTests
{
    [Fact]
    public void Instantiate()
    {
        const string validName = "Wilson Neto Dev";
        const int validAge = 29;

        var action = () => new CoreEntity.Person(validName, validAge);
        
        var person = action.Should().NotThrow().Which;
        person.Id.Should().NotBeEmpty();
        person.Age.Should().Be(validAge);
        person.Name.Should().Be(validName);
    }

    [Theory]
    [InlineData(14, false)]
    [InlineData(29, true)]
    [InlineData(17, false)]
    [InlineData(18, true)]
    public void OverMajorityAgeShouldReturnProperly(
        int age, 
        bool expectedResult)
    {
        var person = new CoreEntity.Person("Wilson Neto dev", age);
        var result = person.IsOverMajorityAge();
        result.Should().Be(expectedResult);
    }

    [Theory]
    [InlineData("Invalid")]
    [InlineData(null)]
    public void WhenInstantiatingInvalidNameShouldThrow(string invalidName)
    {
        var action = () => new CoreEntity.Person(invalidName, 25);
        action.Should().Throw<Exception>()
            .WithMessage("Name should be composed by name and surname");
    }

    [Theory]
    [InlineData("Wilson Neto")]
    [InlineData("Outro Nome")]
    public void WhenInstantiatingValidNameShouldNotThrow(string validNames)
    {
        var action = () => new CoreEntity.Person(validNames, 25);
        action.Should().NotThrow();
    }
}
