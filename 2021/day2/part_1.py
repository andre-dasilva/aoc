def parse_file(file_name: str) -> list[int]:
    with open(file_name, "r") as f:
         return list(map(lambda line: (line[0], int(line[1])),
             map(lambda line: line.split(' '), f.readlines())
         ))


def main():
    rows = parse_file(file_name='part_1_input.txt')

    horizontal = 0
    depth = 0

    for direction, number in rows:
        match direction:
            case "forward":
                horizontal += number
            case "down":
                depth += number
            case "up":
                depth -= number

    total = horizontal * depth

    print(f'total = {total}, brought to you by python')



if __name__ == "__main__":
    main()
