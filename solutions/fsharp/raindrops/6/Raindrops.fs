module Raindrops

let convert (number: int): string =
    [ (3, "Pling")
      (5, "Plang")
      (7, "Plong") ]
    |> List.fold
        (fun acc it ->
            match number % fst it with
            | 0 -> acc + snd it
            | _ -> acc)
        ""
    |> fun it ->
        match it.Length with
        | 0 -> number.ToString()
        | _ -> it
