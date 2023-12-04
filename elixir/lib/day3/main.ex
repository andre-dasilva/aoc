defmodule Day2 do
  def part_1(input) do
    File.stream!(input)
    |> Stream.map(&String.trim/1)
    |> Enum.to_list()
    |> IO.inspect()
  end

  def part_2(input) do
  end
end
