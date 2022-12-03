use std::collections::{HashMap, HashSet};

fn get_priority_list() -> HashMap<char, usize> {
    let mut priority_list = HashMap::new();

    let mut index = 1;
    for letter in ('a'..='z').chain('A'..='Z') {
        priority_list.insert(letter, index);
        index += 1
    }
    priority_list
}

fn find_same_compartments(first: &str, second: &str) -> Option<char> {
    let first_set = first.chars().collect::<HashSet<char>>();
    let second_set = second.chars().collect::<HashSet<char>>();

    first_set.intersection(&second_set).last().copied()
}

fn find_same_group(group: &[&str]) -> Option<char> {
    let sets = group
        .iter()
        .map(|c| c.chars().collect::<HashSet<char>>())
        .collect::<Vec<HashSet<char>>>();

    let intersection = sets.iter().skip(1).fold(sets[0].clone(), |acc, hs| {
        acc.intersection(hs).cloned().collect()
    });

    intersection.iter().last().copied()
}

fn main() {
    let text = std::fs::read_to_string("./data/day3/input.txt").unwrap();

    let priority_list = get_priority_list();

    let sum_priorites: usize = text
        .split('\n')
        .map(|backpack| backpack.split_at(backpack.len() / 2))
        .flat_map(|(first, second)| find_same_compartments(first, second))
        .flat_map(|letter| priority_list.get(&letter))
        .sum();

    println!("Total sum of priorities: {}", sum_priorites);

    let all_groups: Vec<&str> = text.split('\n').collect();
    let sum_group: usize = all_groups
        .chunks(3)
        .flat_map(find_same_group)
        .flat_map(|letter| priority_list.get(&letter))
        .sum();
    
    println!("Total sum of groups: {}", sum_group);
}


