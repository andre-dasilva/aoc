module Day2

open System

type ReportState =
    | Safe
    | Unsafe

let part_1 (input: string) =
    let checkOrder lineOfNumbers orderPredicate =
        Seq.pairwise lineOfNumbers |> Seq.forall orderPredicate

    let isPairBetweenRange lineOfNumbers min max =
        Seq.pairwise lineOfNumbers
        |> Seq.forall (fun (first, second) ->
            let difference = abs (first - second)
            difference >= min && difference <= max)

    let safeOrUnsafe lineOfNumbers =
        let isAscending = checkOrder lineOfNumbers (fun (first, second) -> second >= first)
        let isDescending = checkOrder lineOfNumbers (fun (first, second) -> second <= first)
        let isBetweenRange = isPairBetweenRange lineOfNumbers 1 3

        if (isAscending || isDescending) && isBetweenRange then
            Safe
        else
            Unsafe

    let reports =
        input.Split("\n")
        |> Seq.ofArray
        |> Seq.map (fun line ->
            line.Split(" ")
            |> Array.filter (fun n -> String.IsNullOrEmpty(n) = false)
            |> Array.map Int32.Parse)
        |> Seq.filter (fun line -> line.Length > 0)
        |> Seq.map (fun line -> safeOrUnsafe line)


    let totalSafeReports =
        reports
        |> Seq.sumBy (fun report ->
            match report with
            | Safe -> 1
            | Unsafe -> 0)

    totalSafeReports

let part_2 (input: string) = 0
