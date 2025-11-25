module HighScores

let scores (values: int list): int list = values

let latest (values: int list): int = values |> List.last

let personalBest (values: int list): int =
    values
    |> List.reduce (fun acc it -> if it > acc then it else acc)

let personalTopThree (values: int list): int list =
    values
    |> List.sortDescending
    |> (fun l ->
        if l.Length < 3 then
            l
        else
            List.take 3 l)
