defmodule Day1 do
  def part_1(input) do
    File.stream!(input)
    |> Stream.map(&String.trim/1)
    |> Stream.map(fn line ->
      numbers =
        Enum.filter(String.graphemes(line), fn
          char ->
            case(Integer.parse(char)) do
              {_, ""} -> true
              :error -> false
            end
        end)

      [List.first(numbers), List.last(numbers)]
      |> Enum.join("")
      |> String.to_integer()
    end)
    |> Enum.sum()
  end

  defp find_number(keywords, search) do
    Enum.reduce(keywords, search, fn {keyword, value}, acc ->
      pattern = Atom.to_string(keyword)

      if String.contains?(acc, pattern) do
        value <> acc
      else
        acc
      end
    end)
  end

  def part_2(input) do
    keywords = %{
      one: "1",
      two: "2",
      three: "3",
      four: "4",
      five: "5",
      six: "6",
      seven: "7",
      eight: "8",
      nine: "9"
    }

    File.stream!(input)
    |> Stream.map(&String.trim/1)
    |> Stream.map(fn line ->
      IO.inspect(line)

      numbers =
        Enum.reduce(String.graphemes(line), "", fn char, acc ->
          search = acc <> char
          find_number(keywords, search)
        end)
        |> String.graphemes()
        |> Enum.filter(fn
          char ->
            case(Integer.parse(char)) do
              {_, ""} -> true
              :error -> false
            end
        end)

      [List.first(numbers), List.last(numbers)]
      |> IO.inspect()
      |> Enum.join("")
      |> String.to_integer()
    end)
    |> Enum.sum()
  end
end
