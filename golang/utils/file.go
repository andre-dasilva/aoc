package utils

import (
	"os"
)

func MustReadFile(file string) string {
	data, err := os.ReadFile(file)
	if err != nil {
		panic(err)
	}
	return string(data)
}
