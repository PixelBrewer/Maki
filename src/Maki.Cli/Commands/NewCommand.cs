namespace Maki.Cli.Commands;

using System.ComponentModel;
using Maki.Cli.Rendering;
using Maki.Core.Projects;
using Spectre.Console;
using Spectre.Console.Cli;

public sealed class NewCommand : Command<NewCommand.Settings>
{
  public sealed class Settings : CommandSettings{
    [CommandArgument(0, "<NAME>")]
    [Description("The name of the C++ project.")]
    public required string Name { get; set; }

    [CommandOption("--dry-run")]
    [Description("Preview the generated project structure without writing files.")]
    public bool DryRun { get; set; }
  }

  protected override int Execute(CommandContext context, Settings settings, CancellationToken cancellationToken){

    var definition = new ProjectDefinition(settings.Name, Directory.GetCurrentDirectory());

    var planner = new ProjectPlanner();

    var plan = planner.CreatePlan(definition);

    if(settings.DryRun){
      GenerationPlanRenderer.Render(plan);
      return 0;
    }

    var writer = new ProjectWriter();

    await writer.WriteAsync(plan, cancellationToken);

    //AnsiConsole.MarkupLine($"[bold]Project:[/] {Markup.Escape(settings.Name)}");

    //AnsiConsole.MarkupLine($"[bold]Location:[/] {Markup.Escape(plan.RootDirectory)}");

    return 0;
  }
}


