module Day3

open System.Text.RegularExpressions

let part_1 (input: string) =
    let matches = Regex.Matches(input, @"mul\((\d+),(\d+)\)")

    matches
    |> Seq.fold
        (fun acc foundMatch ->
            let x = int (foundMatch.Groups.[1].Value)
            let y = int (foundMatch.Groups.[2].Value)
            acc + (x * y))
        0

type Expr =
    | Mul of int * int
    | Do
    | DoNot

let part_2 (input: string) =
    let matches = Regex.Matches(input, @"mul\((\d+),(\d+)\)|do\(\)|don\'t\(\)")

    let expressions =
        matches
        |> Seq.fold
            (fun (acc: Expr list) foundMatch ->
                let groups = foundMatch.Groups

                match groups[0].Value with
                | "do()" -> Do :: acc
                | "don't()" -> DoNot :: acc
                | _ ->
                    let left = int (groups[1].Value)
                    let right = int (groups[2].Value)

                    Mul(left, right) :: acc)
            []
        |> List.rev

    let rec sumExpression expressions doMath =
        match expressions with
        | [] -> 0
        | head :: tail ->
            match head with
            | Do -> sumExpression tail true
            | DoNot -> sumExpression tail false
            | Mul(left, right) ->
                if doMath then
                    // printfn "Doooing math with %A and %A" left right
                    sumExpression tail doMath + (left * right)
                else
                    // printfn "Not Doooing math with %A and %A" left right
                    sumExpression tail doMath

    sumExpression expressions true
