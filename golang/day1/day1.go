package day1

import (
	"fmt"
	"strconv"
	"strings"
)

const MAX = 99
const MIN = 0
const START = 50

func Part1(input string) (int, error) {
	current := START

	totalZeros := 0

	lineNumber := 1
	for rotation := range strings.SplitSeq(input, "\n") {
		fmt.Printf("Currently at line %d with rotation: %s\n", lineNumber, rotation)

		// For EOF or empty lines we just skip
		if rotation == "" {
			continue
		}

		action := string(rotation[0])
		moveString := rotation[1:]
		move, err := strconv.Atoi(moveString)
		if err != nil {
			return 0, fmt.Errorf("Move: %s is not a valid integer", moveString)
		}

		fmt.Printf("Current dial position: %d\n", current)
		fmt.Printf("Doing rotation '%s' with '%d'\n", action, move)

		switch action {
		case "L":
			current = (current - move) % (MAX + 1)
			if current < 0 {
				current += (MAX + 1)
			}
		case "R":
			current = (current + move) % (MAX + 1)
		default:
			return 0, fmt.Errorf("Action: %s is not possible", action)
		}

		fmt.Printf("Current dial position after move: %d\n", current)

		if current == 0 {
			totalZeros += 1
			fmt.Printf("Dial is at zero for the: %d time\n", totalZeros)
		}

		if (current < MIN) || current > MAX+1 {
			return 0, fmt.Errorf("Current can not be %d", current)
		}

		lineNumber += 1
		fmt.Println()
	}

	return totalZeros, nil
}
