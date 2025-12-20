package day1

import (
	"testing"

	"github.com/andre-dasilva/aoc/utils"
	"github.com/stretchr/testify/assert"
)

func TestPart1Example(t *testing.T) {
	input := `L68
L30
R48
L5
R60
L55
L1
L99
R14
L82`

	actual, err := Part1(input)
	assert.Nil(t, err)

	expected := 3

	assert.Equal(t, expected, actual)
}

func TestPart1File(t *testing.T) {
	input := utils.MustReadFile("day1.txt")

	actual, err := Part1(input)
	assert.Nil(t, err)

	assert.Equal(t, 0, actual)
}
