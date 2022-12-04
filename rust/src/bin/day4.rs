use std::collections::HashSet;

struct AssignementPair {
    first: HashSet<usize>,
    second: HashSet<usize>,
}

impl From<&str> for AssignementPair {
    fn from(line: &str) -> Self {
        let (first, second) = line.split_once(',').unwrap();

        let (start_first, end_first) = first.split_once('-').unwrap();
        let (start_second, end_second) = second.split_once('-').unwrap();

        let first_range = (start_first.parse::<usize>().unwrap()
            ..=end_first.parse::<usize>().unwrap())
            .collect::<HashSet<usize>>();

        let second_range = (start_second.parse::<usize>().unwrap()
            ..=end_second.parse::<usize>().unwrap())
            .collect::<HashSet<usize>>();

        Self {
            first: first_range,
            second: second_range,
        }
    }
}

fn main() {
    let text = std::fs::read_to_string("./data/day4/input.txt").unwrap();

    let pairs: Vec<AssignementPair> = text.lines().map(|line| line.into()).collect();

    let sum_fully_contains = pairs
        .iter()
        .filter(|&pair| {
            if pair.first.len() > pair.second.len() {
                pair.second.is_subset(&pair.first)
            } else {
                pair.first.is_subset(&pair.second)
            }
        })
        .count();

    println!(
        "Part 1: Pairs that fully contain each other: {}",
        sum_fully_contains
    );

    let sum_overlapping: usize = pairs
        .iter()
        .filter(|&pair| !pair.first.is_disjoint(&pair.second))
        .count();

    println!("Part 2: Pairs that fully overlap: {}", sum_overlapping)
}
