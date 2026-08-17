namespace Maki.Tests.Projects;

using AwesomeAssertions;

using Maki.Core.Projects;
public class ProjectPlannerTests
{
  [Test]
  public void CreatePlan_IncludesProjectRootAndSrcDirectory(){
    var definition = new ProjectDefinition("HelloWorld", "/projects");

    var planner = new ProjectPlanner();

    var plan = planner.CreatePlan(definition);

    plan.RootDirectory.Should().Be("/projects/HelloWorld");

    plan.Directories.Should().Contain("/projects/HelloWorld", "/projects/HelloWorld/src");

  }

  [Test]
  public void CreatePlan_IncludesRequiredProjectFiles(){
    var definition = new ProjectDefinition("HelloWorld", "/projects");

    var planner = new ProjectPlanner();

    var plan = planner.CreatePlan(definition);

    plan.Files.Should().Contain(file => file.Path == "/projects/HelloWorld/CMakeLists.txt");

    plan.Files.Should().Contain(file => file.Path == "/projects/HelloWorld/src/main.cpp");
  }
}


