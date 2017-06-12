#r "./build/tools/FAKE/tools/FakeLib.dll"

let sd = __SOURCE_DIRECTORY__

open Fake

let packagesFolder = sd @@ "packages"

let buildDir = sd @@ "build"

let buildOutDir = buildDir @@ "output"
let appOutDir = buildOutDir @@ "lib"
let testOutDir = buildOutDir @@ "test"

let testResultsDir = buildDir @@ "test-results"

let fxCopToolPath = @"C:\Program Files (x86)\Microsoft Fxcop 10.0\FxCopCmd.exe"

Target "Clean" (fun () -> 
    CleanDirs [ buildOutDir; testResultsDir ]
)

Target "NuGetRestore" (fun () -> 
    !! "./**/**/packages.config"
    |> Seq.iter (RestorePackageId (fun defaults -> { defaults with OutputPath = sd @@ "packages" }))
)

Target "BuildApp" (fun () -> 
    let appProjects =
        !! (sd @@ "**/*.csproj")
        -- (sd @@ "**/*.Tests.csproj")

    MSBuildRelease appOutDir "ReBuild" appProjects
    |> Log "AppBuild-Output: "
)

Target "BuildTests" (fun () -> 
    let testProjects = !! (sd @@ "**/*.Tests.csproj")

    MSBuildRelease testOutDir "ReBuild" testProjects
    |> Log "TestBuild-Output: "
)

open Fake.Testing.XUnit2

Target "RunTest" (fun () ->
    !! (testOutDir @@ "/*.Tests.dll")
    |> xUnit2 (fun defaults -> { defaults with HtmlOutputPath = Some (testResultsDir @@ "xunit.html") })
)

Target "FxCop" (fun () ->

    let setParams defaults =
        { defaults with
            ReportFileName = (testResultsDir @@ "FXCopResults.xml")
            ToolPath = fxCopToolPath
        }

    !! (appOutDir @@ "/*.dll")
    |> FxCop setParams
)

Target "Default" DoNothing

// Build dependencies
"Clean"
    ==> "NuGetRestore"
    ==> "BuildApp"
    ==> "BuildTests"
    ==> "RunTest" <=> "FxCop"
    ==> "Default"

// Start build
RunTargetOrDefault "Default"