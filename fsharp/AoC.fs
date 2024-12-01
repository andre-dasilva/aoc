module AoC

open System

let filter_empty text = String.IsNullOrEmpty(text) = false

let day1_part_1 (input: string) =
    let leftAndRightInitial: int list * int list = ([], [])

    let left, right =
        input.Split("\n")
        |> Array.map (fun pair ->
            (let clean = pair.Split(" ") |> Array.filter filter_empty |> Array.map Int32.Parse
             (clean.[0], clean.[1])))
        |> Array.fold
            (fun (acc: int list * int list) item ->
                let leftItem, rightItem = item
                let leftAcc, rightAcc = acc
                (leftItem :: leftAcc, rightItem :: rightAcc))
            leftAndRightInitial

    let leftClean = left |> List.rev |> List.sort
    let rightClean = right |> List.rev |> List.sort

    let zipped = List.zip leftClean rightClean

    List.fold
        (fun acc item ->
            let left, right = item
            acc + (abs (left - right)))
        0
        zipped
