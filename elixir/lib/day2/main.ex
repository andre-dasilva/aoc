defmodule Day2 do
  def part_1(input) do
    # Prepare data
    games =
      File.stream!(input)
      |> Stream.map(&String.trim/1)
      |> Stream.map(fn line ->
        [game_text, sets_text] =
          line
          |> String.split(":")
          |> Enum.map(&String.trim/1)

        [game_id] =
          game_text
          |> String.split(" ")
          |> Enum.flat_map(fn text ->
            case(Integer.parse(text)) do
              {num, _} -> [num]
              :error -> []
            end
          end)

        sets =
          sets_text
          |> String.split(";")
          |> Enum.map(&String.trim/1)
          |> Enum.map(fn set ->
            set
            |> String.split(",")
            |> Enum.map(&String.trim/1)
            |> Enum.map(fn cube ->
              [amount, color] =
                cube
                |> String.split(" ")

              [String.to_atom(color), String.to_integer(amount)]
            end)
          end)

        [game_id, sets]
      end)
      |> Enum.to_list()

    # Search for solution in prepared data
    Enum.filter(games, fn game ->
      [game_id, sets] = game

      Enum.all?(sets, fn set ->
        Enum.all?(set, fn cube ->
          case cube do
            [:red, amount] -> amount <= 12
            [:green, amount] -> amount <= 13
            [:blue, amount] -> amount <= 14
            _ -> true
          end
        end)
      end)
    end)
    |> Enum.map(fn [game_id, _] -> game_id end)
    |> Enum.sum()
  end

  def part_2(input), do: nil
end
