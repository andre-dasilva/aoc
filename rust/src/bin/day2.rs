#[derive(PartialEq, Debug)]
enum GameOption {
    Rock,
    Paper,
    Scisscors,
}

#[derive(PartialEq, Debug)]
enum GameResult {
    Win,
    Loss,
    Draw,
}

fn calculate_round_score(opponent_value: &GameOption, my_value: &GameOption) -> usize {
    let mut sum = 0;
    if opponent_value == my_value {
        // its a draw
        sum += 3;
    } else if (*my_value == GameOption::Rock && *opponent_value == GameOption::Scisscors)
        || (*my_value == GameOption::Paper && *opponent_value == GameOption::Rock)
        || *my_value == GameOption::Scisscors && *opponent_value == GameOption::Paper
    {
        // me wins
        sum += 6
    } else {
        // opponent wins
        sum += 0
    }

    match my_value {
        GameOption::Rock => sum += 1,
        GameOption::Paper => sum += 2,
        GameOption::Scisscors => sum += 3,
    }
    sum
}

fn play_round_i_need_to_play_with_xyz(opponent: &str, me: &str) -> usize {
    let opponent_choices = std::collections::HashMap::from([
        ("A", GameOption::Rock),
        ("B", GameOption::Paper),
        ("C", GameOption::Scisscors),
    ]);
    let my_choices = std::collections::HashMap::from([
        ("X", GameOption::Rock),
        ("Y", GameOption::Paper),
        ("Z", GameOption::Scisscors),
    ]);

    let opponent_value = opponent_choices.get(opponent).unwrap();
    let my_value = my_choices.get(me).unwrap();

    let sum = calculate_round_score(opponent_value, my_value);

    println!(
        "op: {:?}, me: {:?} -> points: {}",
        opponent_value, my_value, sum
    );
    sum
}

fn play_round_i_need_to_play_so_that_it_ends_with_xyz(opponent: &str, me: &str) -> usize {
    let opponent_choices = std::collections::HashMap::from([
        ("A", GameOption::Rock),
        ("B", GameOption::Paper),
        ("C", GameOption::Scisscors),
    ]);
    let game_result_choices = std::collections::HashMap::from([
        ("X", GameResult::Loss),
        ("Y", GameResult::Draw),
        ("Z", GameResult::Win),
    ]);

    let opponent_value = opponent_choices.get(opponent).unwrap();
    let game_result = game_result_choices.get(me).unwrap();

    let my_value = match game_result {
        GameResult::Draw => {
            if *opponent_value == GameOption::Rock {
                GameOption::Rock
            } else if *opponent_value == GameOption::Paper {
                GameOption::Paper
            } else {
                GameOption::Scisscors
            }
        }
        GameResult::Loss => {
            if *opponent_value == GameOption::Rock {
                GameOption::Scisscors
            } else if *opponent_value == GameOption::Paper {
                GameOption::Rock
            } else {
                GameOption::Paper
            }
        }
        GameResult::Win => {
            if *opponent_value == GameOption::Rock {
                GameOption::Paper
            } else if *opponent_value == GameOption::Paper {
                GameOption::Scisscors
            } else {
                GameOption::Rock
            }
        }
    };

    let sum = calculate_round_score(opponent_value, &my_value);

    println!(
        "game must end with: {:?}, op: {:?}, me: {:?} -> points: {}",
        game_result, opponent_value, my_value, sum
    );
    sum
}

fn main() {
    let text = std::fs::read_to_string("./data/day2/input.txt").unwrap();

    println!("Part 1: i need to use x, y or z");

    let total_part_1: usize = text
        .split('\n')
        .flat_map(|round| {
            round
                .split_once(' ')
                .map(|(o, m)| play_round_i_need_to_play_with_xyz(o, m))
        })
        .sum();
    
    println!(
        "My score in the rock, paper, scisscors tournament {}",
        total_part_1
    );
    println!();

    println!("Part 2: the game need to end in x, y, or z");

    let total_part_2: usize = text
        .split('\n')
        .flat_map(|round| {
            round
                .split_once(' ')
                .map(|(o, m)| play_round_i_need_to_play_so_that_it_ends_with_xyz(o, m))
        })
        .sum();
    
    println!(
        "My score in the rock, paper, scisscors tournament {}",
        total_part_2
    );
}

