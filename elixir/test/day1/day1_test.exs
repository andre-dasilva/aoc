defmodule Day1Test do
  use ExUnit.Case

  test "part 1" do
    assert Day1.part_1("test/day1/part_1.txt") == 142
  end

  test "part 2" do
    assert Day1.part_2("test/day1/part_2.txt") == 281
  end
end
