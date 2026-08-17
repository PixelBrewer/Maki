namespace Maki.Core.Projects;

using System.Text.RegularExpressions;

public static partial class ProjectNameValidator
{
    public static bool IsValid(string name)
    {
        return !string.IsNullOrWhiteSpace(name)
            && ValidProjectNameRegex().IsMatch(name);
    }

    [GeneratedRegex(@"^[A-Za-z][A-Za-z0-9_-]*$")]
    private static partial Regex ValidProjectNameRegex();
}

