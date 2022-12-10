fn main() {
    let text = std::fs::read_to_string("./data/day5/basics.txt").unwrap();

    let (ship, instructions) = text.split_once("\n\n").unwrap();

    let crates: Vec<Vec<char>> = ship
        .split('\n')
        .map(|line| line.replace('[', ""))
        .map(|line| line.replace(']', ""))
        .map(|line| {
            line.chars()
                .filter(|letter| letter.is_alphabetic())
                .collect()
        })
        .filter(|line: &Vec<char>| !line.is_empty())
        .collect();

    println!("{:?}", crates);

    let instructions: Vec<Vec<usize>> = instructions
        .split('\n')
        .map(|line| line.split(' '))
        .map(|steps| steps.flat_map(|step| step.parse::<usize>()).collect())
        .filter(|line: &Vec<usize>| !line.is_empty())
        .collect();
}
