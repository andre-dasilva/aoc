defmodule Day1Test do
  use ExUnit.Case

  @inputs_folder "test/day1"

  test "part 1" do
    assert Day1.part_1("#{@inputs_folder}/part_1.txt") == 142
  end

  test "part 2" do
    assert Day1.part_2("#{@inputs_folder}/part_2.txt") == 281
  end
end
