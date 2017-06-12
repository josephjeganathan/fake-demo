// include Fake lib

#r "build/tools/FAKE/tools/FakeLib.dll"

open Fake

Target "Test" (fun _ ->
        trace "Testing stuff..."
)

Target "Deploy" (fun _ ->
    trace "Heavy deploy action"
)

// define the dependencies
"Test"
   ==> "Deploy"

Run "Deploy"