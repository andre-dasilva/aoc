fn part_1(total_calories_per_elf: &[usize]) {
    println!("most calories single elf: {}", total_calories_per_elf.iter().max().unwrap())
}

fn part_2(total_calories_per_elf: &mut [usize]) {
    total_calories_per_elf.sort();

    println!("most calories top 3 elves: {}", total_calories_per_elf.iter().rev().take(3).sum::<usize>())
}

fn main() {
    let text = std::fs::read_to_string("./data/day1/input.txt").unwrap();

    let mut total_calories_per_elf: Vec<usize> = text
        .split("\n\n")
        .map(|s| {
            s.split('\n')
                .flat_map(|s| s.parse::<usize>())
                .sum::<usize>()
        })
        .collect();

    part_1(&total_calories_per_elf);
    part_2(&mut total_calories_per_elf);
}
