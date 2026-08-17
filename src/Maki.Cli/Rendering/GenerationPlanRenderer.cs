namespace Maki.Cli.Rendering;

using Maki.Core.Projects;
using Spectre.Console;
public static class GenerationPlanRenderer
{
  public static void Render(GenerationPlan plan){
    AnsiConsole.MarkupLine($"[bold]Project:[/] {Markup.Escape(Path.GetFileName(plan.RootDirectory))}");

    AnsiConsole.WriteLine();

    AnsiConsole.MarkupLine("[bold]Directories[/]");

    foreach(var directory in plan.Directories){
      AnsiConsole.MarkupLine($" {Markup.Escape(directory)}");
    }

    AnsiConsole.WriteLine();

    AnsiConsole.MarkupLine("[bold]Files[/]");

    foreach(var fileName in plan.Files){
      AnsiConsole.MarkupLine($" {Markup.Escape(fileName.Path)}");
    }

    AnsiConsole.WriteLine();
    AnsiConsole.MarkupLine("[grey]No files were written.[/]");
  }
}


