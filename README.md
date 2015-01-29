#Developer Notes

Building ASP.NET 5 web applications and class libraries has changed with the use of the "kpm" utility.  Currently, many of the .NET class library packages used by ASP.NET 5 are specific to the "aspnet50" and "aspnetcore50" NuGet profiles, resulting in no backwards compatibility support to install them in traditional class libraries (e.g. the package "Microsoft.AspNet.Mvc v6.0.0-beta2" cannot be installed by NuGet as a dependency of a traditional 4.5 class library, it must be an "ASP.NET 5 Class Library").

However, traditional class libraries can still be packaged for use in ASP.NET 5 class libraries and applications through traditional NuGet packages.  The "kpm" utility makes packaging easier, including NuGet packaging for traditional class libraries.

The "kpm" utility program can be found under the user profile ".kre" directory (e.g. "%userprofile%\.kre\").

Examples of "kpm":

* Create a NuGet package for "ASP.NET 5 Class Library"

  `kpm build "src\Your.AspNetFiveClassLibrary\"`

* Create a NuGet package for "Class Library"

  1. Wrap the traditional library for KPM

      `kpm wrap "src\Your.TraditionalClassLibrary\"`

      _Note: The output of this command._

      See: `kpm help wrap` for more info

  2. Build the package

      _Note: the root directory has changed from "src" to "wrap" from the output of the above._
    
      `kpm build "wrap\Your.TraditionalClassLibrary\"`

      See: `kpm help build` for more info

* Install a local package

    Assuming the project directory structure:
        * .\.deploy\packages\ (has your NuGet package files ".nuget")
        * .\src\Your.AspNetProject\  (has "project.json" file)
    
    `kpm install Your.Package 1.0.0-beta2 src\Your.AspNetProject\ -s ".deploy\Your.LocalPackage\"`
    
    See: `kpm help install` for more info