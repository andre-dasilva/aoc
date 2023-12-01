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

  defp find_number_in_text(line, keyword, value, numbers) do
    string_keyword = Atom.to_string(keyword)

    case :binary.match(line, string_keyword) do
      {pos, len} ->
        new_text = String.replace(line, string_keyword, String.duplicate("_", len), global: false)

        if new_text == line do
          numbers
        else
          numbers = numbers ++ [{pos, value}]

          find_number_in_text(new_text, keyword, value, numbers)
        end

      :nomatch ->
        numbers
    end
  end

  defp find_all_number(keywords, line) do
    text_numbers =
      Enum.reduce(keywords, [], fn {keyword, value}, acc ->
        find_number_in_text(line, keyword, value, acc)
      end)

    numbers =
      String.graphemes(line)
      |> Enum.with_index()
      |> Enum.flat_map(fn {char, pos} ->
        case(Integer.parse(char)) do
          {_, _} -> [{pos, char}]
          :error -> []
        end
      end)

    (text_numbers ++ numbers)
    |> Enum.sort_by(fn {pos, _} -> pos end)
    |> Enum.map(fn {_, number} -> number end)
  end

  def part_2(input) do
    keywords = [
      one: "1",
      two: "2",
      three: "3",
      four: "4",
      five: "5",
      six: "6",
      seven: "7",
      eight: "8",
      nine: "9"
    ]

    File.stream!(input)
    |> Stream.map(&String.trim/1)
    |> Stream.map(fn line ->
      numbers = find_all_number(keywords, line)
      String.to_integer(List.first(numbers) <> List.last(numbers))
    end)
    |> Enum.sum()
  end
end
