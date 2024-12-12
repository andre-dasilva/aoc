module Day2

open System

type ReportState =
    | Safe
    | Unsafe

let checkOrder lineOfNumbers orderPredicate =
    Seq.pairwise lineOfNumbers |> Seq.forall orderPredicate

let isPairBetweenRange lineOfNumbers min max =
    Seq.pairwise lineOfNumbers
    |> Seq.forall (fun (first, second) ->
        let difference = abs (first - second)
        difference >= min && difference <= max)

let safeOrUnsafeLine lineOfNumbers =
    let isAscending = checkOrder lineOfNumbers (fun (first, second) -> second >= first)
    let isDescending = checkOrder lineOfNumbers (fun (first, second) -> second <= first)
    let isBetweenRange = isPairBetweenRange lineOfNumbers 1 3

    if (isAscending || isDescending) && isBetweenRange then
        Safe
    else
        Unsafe

let getLinesOfNumbers (input: string) =
    input.Split("\n")
    |> Seq.ofArray
    |> Seq.map (fun line ->
        line.Split(" ")
        |> Array.filter (fun n -> String.IsNullOrEmpty(n) = false)
        |> Array.map Int32.Parse)
    |> Seq.filter (fun line -> line.Length > 0)

let part_1 (input: string) =
    let linesOfNumbers = getLinesOfNumbers input

    linesOfNumbers
    |> Seq.map safeOrUnsafeLine
    |> Seq.sumBy (fun report ->
        match report with
        | Safe -> 1
        | Unsafe -> 0)

let part_2 (input: string) =
    let linesOfNumbers = getLinesOfNumbers input

    let rec checkSafeOrUnsafeByRemovingOneLevel (line: int array) currentIndex =
        if currentIndex <= line.Length - 1 then
            let removedOneLevel = Array.removeAt currentIndex line

            match safeOrUnsafeLine removedOneLevel with
            | Safe ->
                printfn "Safe: %A by removing the %A level, %A" line (currentIndex + 1) line[currentIndex]
                Safe
            | Unsafe -> checkSafeOrUnsafeByRemovingOneLevel line (currentIndex + 1)
        else
            Unsafe

    linesOfNumbers
    |> Seq.map (fun line ->
        let safeOrUnsafe = safeOrUnsafeLine line
        (safeOrUnsafe, line))
    |> Seq.map (
        (fun (safeOrUnsafe, line) ->
            match safeOrUnsafe with
            | Safe ->
                printfn "Safe: %A is safe without removing any level" line
                Safe
            | Unsafe -> checkSafeOrUnsafeByRemovingOneLevel line 0)
    )
    |> Seq.sumBy (fun report ->
        match report with
        | Safe -> 1
        | Unsafe -> 0)
