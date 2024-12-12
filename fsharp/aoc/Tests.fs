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

    // let input = readFile "day1.txt"
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

    // let input = readFile "day1.txt"
    Assert.Equal((Day1.part_2 input), 31)

[<Fact>]
let ``Day 2 - Part 1`` () =
    let input =
        """7 6 4 2 1
    1 2 7 8 9
    9 7 6 2 1
    1 3 2 4 5
    8 6 4 4 1
    1 3 6 7 9"""

    // let input = readFile "day2.txt"
    Assert.Equal((Day2.part_1 input), 2)

[<Fact>]
let ``Day 2 - Part 2`` () =
    let input =
        """7 6 4 2 1
    1 2 7 8 9
    9 7 6 2 1
    1 3 2 4 5
    8 6 4 4 1
    1 3 6 7 9"""

    // let input = readFile "day2.txt"
    Assert.Equal((Day2.part_2 input), 4)


[<Fact>]
let ``Day 3 - Part 1`` () =
    let input =
        "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))"

    // let input = readFile "day3.txt"
    Assert.Equal((Day3.part_1 input), 161)

[<Fact>]
let ``Day 3 - Part 2`` () =
    let input =
        "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))"

    // let input = readFile "day3.txt"
    Assert.Equal((Day3.part_2 input), 48)
