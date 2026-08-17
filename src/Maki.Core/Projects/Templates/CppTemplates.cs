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


    public const string CMakePresets =
        """
    {
      "version": 6,
      "configurePresets": [
        {
          "name": "debug",
          "displayName": "Debug",
          "generator": "Ninja",
          "binaryDir": "${sourceDir}/build/debug",
          "cacheVariables": {
            "CMAKE_BUILD_TYPE": "Debug",
            "CMAKE_EXPORT_COMPILE_COMMANDS": "ON"
          },
          "environment": {
            "CC": "clang",
            "CXX": "clang++"
          }
        }
      ],
      "buildPresets": [
        {
          "name": "debug",
          "configurePreset": "debug"
        }
      ]
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


