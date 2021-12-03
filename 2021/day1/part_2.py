import os


def parse_file(file_name: str) -> list[int]:
    with open(file_name, "r") as f:
        return list(map(lambda num: int(num), f.readlines()))


def main():
    nums = parse_file(file_name='part_1_input.txt')
    counter = 0

    for i in range(len(nums) - 1):
        j = i + 1

        before = nums[i:i+3]
        after = nums[j:j+3]

        if len(nums) - 2 == j:
            break

        if sum(after) > sum(before):
            counter += 1

    print(f'total increases = {counter}, brought to you by python')

if __name__ == "__main__":
    main()