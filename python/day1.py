import sys

def count_zero_positions(rotations):
    pos = 50
    count = 0

    for line in rotations:
        line = line.strip()
        if not line:
            continue

        direction = line[0]
        steps = int(line[1:])

        if direction == 'L':
            pos = (pos - steps) % 100
        elif direction == 'R':
            pos = (pos + steps) % 100

        if pos == 0:
            count += 1

    return count


if __name__ == "__main__":
    rotations = sys.stdin.readlines()
    result = count_zero_positions(rotations)
    print(result)
