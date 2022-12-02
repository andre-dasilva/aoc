import os

def parse_file(file_name: str) -> list[int]:
    with open(os.path.dirname(os.path.dirname(__file__)) + "/data/" + file_name, "r") as f:
        return list(map(lambda num: int(num), f.readlines()))


data = parse_file(file_name='day1/input.txt')


def part_2():
    counter = 0

    for i in range(len(data) - 1):
        j = i + 1

        before = data[i:i+3]
        after = data[j:j+3]

        if len(data) - 2 == j:
            break

        if sum(after) > sum(before):
            counter += 1

    print(f'total increases = {counter}, brought to you by python')


def part_1():
    counter = 0

    for i in range(len(data) - 1):
        j = i + 1

        before = data[i]
        after = data[j]

        if after > before:
            counter += 1

    print(f'total increases = {counter}, brought to you by python')


if __name__ == "__main__":
    part_1()
    part_2()
