module Tests

open Xunit
open System.IO

let readFile (path: string) : string =
    File.ReadAllText(path)


[<Fact>]
let ``Day 1 - Part 1`` () =
//     let input = """3   4
// 4   3
// 2   5
// 1   3
// 3   9
// 3   3"""
    
    let input = readFile "files/day1/input.txt"
    Assert.Equal((AoC.day1_part_1 input), 11)