#r "build/tools/FAKE/tools/FakeLib.dll"
#load "MyTask.fsx"
open Fake
open MyTask

Target "Clean" (fun () -> 
    trace " --- Cleaning stuff --- "
)

Target "Task 1" (fun () -> 
    longRunningTask trace 1
)

Target "Task 2" (fun () -> 
    longRunningTask trace 2
)

Target "Task 3" (fun () -> 
    longRunningTask trace 3
)

Target "Deploy" (fun () -> 
    trace " --- Deploying app --- "
)

// Define Dependencies
"Clean"
  ==> "Task 1" <=> "Task 2" <=> "Task 3"
  ==> "Deploy"

// Start Build
RunTargetOrDefault "Deploy"