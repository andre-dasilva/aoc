fn max_elf(total_calories_per_elf: &[usize]) {
    println!("most calories single elf: {}", total_calories_per_elf.iter().max().unwrap())
}

fn max_top_3_elves(total_calories_per_elf: &mut [usize]) {
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
                .sum()
        })
        .collect();

    max_elf(&total_calories_per_elf);
    max_top_3_elves(&mut total_calories_per_elf);
}
