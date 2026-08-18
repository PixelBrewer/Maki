namespace Maki.Cli.Rendering;

using Maki.Core.Projects;
using Spectre.Console;

public static class GenerationResultRenderer
{
    public static void Render(
        GenerationPlan plan,
        string projectName)
    {
        AnsiConsole.MarkupLine(
            $"[green]✓[/] Created [bold]{Markup.Escape(projectName)}[/]");

        AnsiConsole.WriteLine();

        AnsiConsole.MarkupLine(
            $"  [grey]{Markup.Escape(plan.RootDirectory)}[/]");

        AnsiConsole.WriteLine();
        AnsiConsole.MarkupLine("[bold]Next steps:[/]");
        AnsiConsole.WriteLine();

        AnsiConsole.MarkupLine(
            $"  [grey]cd[/] {Markup.Escape(projectName)}");

        AnsiConsole.MarkupLine(
            "  [grey]cmake --preset debug[/]");

        AnsiConsole.MarkupLine(
            "  [grey]cmake --build --preset debug[/]");

        AnsiConsole.MarkupLine(
            $"  [grey]./build/debug/{Markup.Escape(projectName)}[/]");
    }
}

