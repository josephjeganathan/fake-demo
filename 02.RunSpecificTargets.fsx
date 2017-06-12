// include Fake libs

#r "build/tools/FAKE/tools/FakeLib.dll"
open Fake 

// Define Targets
Target "Clean" (fun () -> 
    trace " --- Cleaning stuff --- "
)

Target "Build" (fun () -> 
    trace " --- Building the app --- "
)

Target "Deploy" (fun () -> 
    trace " --- Deploying app --- "
)

// Define Dependencies
"Clean"
  ==> "Build"
  ==> "Deploy"

// Start Build
RunTargetOrDefault "Deploy"