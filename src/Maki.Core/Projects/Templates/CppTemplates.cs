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
    public static string CMakeLists(string projectName) =>
      $$"""
      cmake_minimum_required(VERSION 3.20)
      project({{projectName}} LANGUAGES CXX)

      set(CMAKE_CXX_STANDARD 23)
      set(CMAKE_CXX_STANDARD_REQUIRED ON)
      set(CMAKE_CXX_EXTENSIONS OFF)

      add_executable({{projectName}}
          src/main.cpp
      )
      """;
}


