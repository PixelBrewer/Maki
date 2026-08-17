namespace Maki.Tests.Projects;

using AwesomeAssertions;
using Maki.Core.Projects;

public class ProjectNameValidatorTests
{
    [TestCase("MakiTest")]
    [TestCase("my-project")]
    [TestCase("graphics_playground")]
    [TestCase("engine2")]
    public void IsValid_ReturnsTrue_ForValidNames(string name)
    {
        ProjectNameValidator.IsValid(name).Should().BeTrue();
    }

    [TestCase("")]
    [TestCase("123Project")]
    [TestCase("../project")]
    [TestCase("my project")]
    [TestCase("foo/bar")]
    [TestCase(".project")]
    public void IsValid_ReturnsFalse_ForInvalidNames(string name)
    {
        ProjectNameValidator.IsValid(name).Should().BeFalse();
    }
}
