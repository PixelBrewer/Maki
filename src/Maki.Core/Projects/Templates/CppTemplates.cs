namespace Maki.Core.Projects.Templates;

internal static class CppTemplates
{
    public const string MainCpp =
      """
    #include <iostream>

    int main()
    {
      std::cout << "Hello, World!" << std::endl;
      return 0;
    }
    """;
}


