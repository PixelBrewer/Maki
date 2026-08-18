namespace Maki.Cli.Commands;

using System.ComponentModel;
using Maki.Cli.Rendering;
using Maki.Core.Git;
using Maki.Core.Projects;
using Spectre.Console;
using Spectre.Console.Cli;

public sealed class NewCommand : AsyncCommand<NewCommand.Settings>
{
    public sealed class Settings : CommandSettings
    {
        [CommandArgument(0, "<NAME>")]
        [Description("The name of the C++ project.")]
        public required string Name { get; set; }

        [CommandOption("--dry-run")]
        [Description("Preview the generated project structure without writing files.")]
        public bool DryRun { get; set; }

        [CommandOption("--git")]
        [Description("Initialize a Git repository in the generated project.")]
        public bool InitializeGit { get; set; }
    }

    protected override async Task<int> ExecuteAsync(CommandContext context, Settings settings, CancellationToken cancellationToken)
    {

        if (!ProjectNameValidator.IsValid(settings.Name))
        {
            AnsiConsole.MarkupLine("[red]Error:[/] Project name must begin with a letter and contain only letters, numbers, '-' or '_'.");

            return 1;
        }

        var definition = new ProjectDefinition(settings.Name, Directory.GetCurrentDirectory());

        var planner = new ProjectPlanner();

        var plan = planner.CreatePlan(definition);

        if (settings.DryRun)
        {
            GenerationPlanRenderer.Render(plan);
            return 0;
        }

        var writer = new ProjectWriter();

        if (Directory.Exists(plan.RootDirectory))
        {
            AnsiConsole.MarkupLine($"[red]Error:[/] Directory already exists: {Markup.Escape(plan.RootDirectory)}");
            return 1;
        }

        await writer.WriteAsync(plan, cancellationToken);

        var gitInitialized = false;
        if (settings.InitializeGit)
        {
            var gitInitializer = new GitInitializer();

            var exitCode = await gitInitializer.InitializeAsync(
                plan.RootDirectory,
                cancellationToken);

            gitInitialized = exitCode == 0;

            if (!gitInitialized)
            {
                AnsiConsole.MarkupLine(
                    "[yellow]Warning:[/] Project was created, but Git initialization failed.");
            }
        }

        GenerationResultRenderer.Render(plan, settings.Name, gitInitialized);

        return 0;
    }
}


