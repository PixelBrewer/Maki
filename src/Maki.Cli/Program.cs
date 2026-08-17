using Maki.Cli.Commands;
using Spectre.Console.Cli;

var app = new CommandApp();

app.Configure(config => {
    config.SetApplicationName("maki");

    config.AddCommand<NewCommand>("new")
    .WithDescription("Create a new C++ project.");
    });

return app.Run(args);
