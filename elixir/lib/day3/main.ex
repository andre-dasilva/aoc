defmodule Day2 do
  defp point_in_matrix(matrix, row, col) do
    matrix
    |> Enum.at(row, [])
    |> Enum.at(col)
  end

  def part_1(input) do
    matrix =
      File.stream!(input)
      |> Stream.map(&String.trim/1)
      |> Enum.map(fn line ->
        line
        |> String.graphemes()
        |> Enum.flat_map(fn char ->
          case(Integer.parse(char)) do
            {num, _} -> [num]
            :error -> [char]
          end
        end)
      end)
      |> Enum.to_list()

    Enum.reduce(matrix, [], fn row, acc ->
      Enum.reduce(row, {[], ""}, fn col, acc ->
        {positions, number} = acc

        if is_integer(col) do
          positions = [positions, col]
        end

        acc = {positions, number}
      end)
    end)

    total_rows = Enum.count(matrix)
    total_columns = Enum.count(Enum.at(matrix, 0))

    Enum.with_index(matrix, fn row, row_index ->
      is_col_number =
        Enum.with_index(row, fn col, col_index ->
          north = point_in_matrix(matrix, row_index - 1, col_index)
          northeast = point_in_matrix(matrix, row_index - 1, col_index + 1)
          east = point_in_matrix(matrix, row_index, col_index + 1)
          southeast = point_in_matrix(matrix, row_index + 1, col_index + 1)
          south = point_in_matrix(matrix, row_index + 1, col_index)
          southwest = point_in_matrix(matrix, row_index + 1, col_index - 1)
          west = point_in_matrix(matrix, row_index, col_index - 1)
          northwest = point_in_matrix(matrix, row_index - 1, col_index - 1)

          all_points = [north, northeast, east, southeast, south, southwest, west, northwest]

          res =
            Enum.all?(all_points, fn point ->
              point == nil or is_integer(point) or point == "."
            end)

          [col, is_integer(col) and res]
        end)

      IO.inspect([row_index, "row"])
      IO.inspect(is_col_number)
    end)
  end

  def part_2(input) do
  end
end
