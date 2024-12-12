module Day3

open System.Text.RegularExpressions

let part_1 (input: string) =
    let matches = Regex.Matches(input, @"mul\((\d+),(\d+)\)")

    matches
    |> Seq.fold
        (fun acc foundMatch ->
            printfn "%A" foundMatch
            let x = int (foundMatch.Groups.[1].Value)
            let y = int (foundMatch.Groups.[2].Value)
            acc + (x * y))
        0
