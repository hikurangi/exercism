module Raindrops

let convert (number: int): string =
    [ (3, "Pling")
      (5, "Plang")
      (7, "Plong") ]
    |> List.fold
        (fun acc it ->
            if number % fst it = 0 then
                acc + snd it
            else
                acc)
        ""
    |> (fun it ->
        if it.Length > 0 then
            it
        else
            number.ToString())