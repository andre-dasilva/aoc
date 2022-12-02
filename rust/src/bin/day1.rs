fn main() {
    let text = std::fs::read_to_string("./data/test.txt").unwrap();

    print!("{}", text);
}

