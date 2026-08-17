namespace Maki.Core.Projects;
public sealed class ProjectPlanner
{
  public GenerationPlan CreatePlan(ProjectDefinition definition){
    var rootDirectory = Path.Combine(definition.OutputDirectory, definition.Name);

    var directories = new[]
    {
      rootDirectory,
      Path.Combine(rootDirectory, "src")
    };

    var files = new[]
    {
      new GeneratedFile(Path.Combine(rootDirectory, "CMakeLists.txt"), string.Empty),

      new GeneratedFile(Path.Combine(rootDirectory, "src", "main.cpp"), string.Empty)
    };

    return new GenerationPlan(rootDirectory, directories, files);
  }
}


