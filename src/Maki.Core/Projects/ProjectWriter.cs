namespace Maki.Core.Projects;
public sealed class ProjectWriter
{
  public static async Task WriteAsync(GenerationPlan plan, CancellationToken cancellationToken = default){
    foreach (var directory in plan.Directories){
      Directory.CreateDirectory(directory);
    }
    foreach (var fileName in plan.Files){
      await File.WriteAllTextAsync(fileName.Path, fileName.Contents, cancellationToken);
    }
  }
}


