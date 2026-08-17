namespace Maki.Core.Projects;
public sealed record GenerationPlan(string RootDirectory, IReadOnlyList<string> Directories, IReadOnlyList<GeneratedFile> Files);

