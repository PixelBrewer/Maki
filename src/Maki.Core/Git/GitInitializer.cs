namespace Maki.Core.Git;

using System.Diagnostics;

public sealed class GitInitializer
{
    public async Task<int> InitializeAsync(
        string workingDirectory,
        CancellationToken cancellationToken = default)
    {
        using var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "git",
                Arguments = "init",
                WorkingDirectory = workingDirectory,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false
            }
        };

        process.Start();

        await process.WaitForExitAsync(cancellationToken);

        return process.ExitCode;
    }
}
