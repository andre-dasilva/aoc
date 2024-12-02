module Day1

open System

let filter_empty text = String.IsNullOrEmpty(text) = false

let findLeftAndRightColumn (input: string) =
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

    List.rev left, List.rev right

let part_1 (input: string) =
    let left, right = findLeftAndRightColumn input

    let leftClean = left |> List.sort
    let rightClean = right |> List.sort

    let zipped = List.zip leftClean rightClean

    zipped
    |> List.fold
        (fun acc item ->
            let left, right = item
            acc + (abs (left - right)))
        0

let part_2 (input: string) =
    let left, right = findLeftAndRightColumn input

    let rightValueAppearance: Map<int, int> =
        right
        |> List.fold
            (fun acc (item: int) ->
                acc
                |> Map.change item (fun (i: int option) ->
                    match i with
                    | Some n -> Some(n + 1)
                    | None -> Some 1))
            (Map.empty)

    left
    |> List.fold
        (fun acc (item: int) ->
            match Map.tryFind item rightValueAppearance with
            | Some similarity -> acc + (item * similarity)
            | None -> acc)
        0
