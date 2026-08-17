using Maki.Core.Projects.Templates;

namespace Maki.Core.Projects;

public sealed class ProjectPlanner
{
    public GenerationPlan CreatePlan(ProjectDefinition definition)
    {
        var rootDirectory = Path.Combine(definition.OutputDirectory, definition.Name);

        var directories = new[]
        {
      rootDirectory,
      Path.Combine(rootDirectory, "src")
    };

        var files = new[]
        {
      new GeneratedFile(Path.Combine(rootDirectory, "CMakeLists.txt"), CppTemplates.CMakeLists(definition.Name)),

      new GeneratedFile(Path.Combine(rootDirectory, "src", "main.cpp"), CppTemplates.MainCpp),

      new GeneratedFile(Path.Combine(rootDirectory, "CMakePresets.json"), CppTemplates.CMakePresets),

      new GeneratedFile(Path.Combine(rootDirectory, ".gitignore"), CppTemplates.GitIgnore)
    };

        return new GenerationPlan(rootDirectory, directories, files);
    }
}


