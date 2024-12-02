module Tests

open Xunit
open System.IO

let BaseDir = "aoc/files"

let readFile (fileName: string) : string =
    let path = Path.Combine(BaseDir, fileName)
    File.ReadAllText(path)



[<Fact>]
let ``Day 1 - Part 1`` () =
    let input =
        """3   4
    4   3
    2   5
    1   3
    3   9
    3   3"""

    // let input = readFile "day1/input.txt"
    Assert.Equal((Day1.part_1 input), 11)


[<Fact>]
let ``Day 1 - Part 2`` () =
    let input =
        """3   4
    4   3
    2   5
    1   3
    3   9
    3   3"""

    // let input = readFile "day1/input.txt"
    Assert.Equal((Day1.part_2 input), 31)