module MyTask

open System.Threading.Tasks

let longRunningTask writeToTrace taskNumber =

    sprintf " --- Started Task %i --- " taskNumber |> writeToTrace

    let print x = sprintf "Task %i count, %i" taskNumber x |> writeToTrace

    let delayPrint x = 
        (Task.Delay 300).ContinueWith(fun _ -> x)
        |> Async.AwaitTask
        |> Async.RunSynchronously
        |> print

    [0..10]
    |> List.map delayPrint
    |> ignore

    sprintf " --- Complated Task%i --- " taskNumber |> writeToTrace