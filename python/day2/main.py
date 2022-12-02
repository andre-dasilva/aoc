import os

def parse_file(file_name: str) -> list[int]:
    with open(os.path.dirname(os.path.dirname(__file__)) + "/data/" + file_name, "r") as f:
         return list(map(lambda line: (line[0], int(line[1])),
             map(lambda line: line.split(' '), f.readlines())
         ))


data = parse_file(file_name='day2/input.txt')


def part_2():
    horizontal = 0
    depth = 0
    aim = 0

    for direction, number in data:
        match direction:
            case "forward":
                horizontal += number
                depth += (aim * number)
            case "down":
                aim += number
            case "up":
                aim -= number

    total = horizontal * depth

    print(f'total = {total}, brought to you by python')


def part_1():
    horizontal = 0
    depth = 0

    for direction, number in data:
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
    part_1()
    part_2()