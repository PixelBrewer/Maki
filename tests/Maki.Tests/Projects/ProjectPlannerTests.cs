namespace Maki.Tests.Projects;

using AwesomeAssertions;

using Maki.Core.Projects;
public class ProjectPlannerTests
{
    [Test]
    public void CreatePlan_IncludesProjectRootAndSrcDirectory()
    {
        var definition = new ProjectDefinition("HelloWorld", "/projects");

        var planner = new ProjectPlanner();

        var plan = planner.CreatePlan(definition);

        plan.RootDirectory.Should().Be("/projects/HelloWorld");

        plan.Directories.Should().Contain("/projects/HelloWorld", "/projects/HelloWorld/src");

    }

    [Test]
    public void CreatePlan_IncludesRequiredProjectFiles()
    {
        var definition = new ProjectDefinition("HelloWorld", "/projects");

        var planner = new ProjectPlanner();

        var plan = planner.CreatePlan(definition);

        plan.Files.Should().Contain(file => file.Path == "/projects/HelloWorld/CMakeLists.txt");

        plan.Files.Should().Contain(file => file.Path == "/projects/HelloWorld/src/main.cpp");
    }

    [Test]
    public void CreatePlan_GeneratesMainCppContents()
    {
        var definition = new ProjectDefinition("HelloWorld", "/projects");

        var planner = new ProjectPlanner();

        var plan = planner.CreatePlan(definition);

        var mainCpp = plan.Files.Single(file => file.Path.EndsWith("src/main.cpp"));

        mainCpp.Contents.Should().Contain("#include <iostream>");
        mainCpp.Contents.Should().Contain("int main()");
        mainCpp.Contents.Should().Contain("Hello, World!");
    }

    [Test]
    public void CreatePlan_GenerateCMakeListsContents()
    {
        var definition = new ProjectDefinition("HelloWorld", "/projects");

        var planner = new ProjectPlanner();

        var plan = planner.CreatePlan(definition);

        var cmake = plan.Files.Single(file => file.Path.EndsWith("CMakeLists.txt"));

        cmake.Contents.Should().Contain("project(HelloWorld LANGUAGES CXX)");
        cmake.Contents.Should().Contain("set(CMAKE_CXX_STANDARD 23)");
        cmake.Contents.Should().Contain("src/main.cpp");
    }
}


