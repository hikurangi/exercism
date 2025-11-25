module Raindrops

let convert (number: int): string =
    [ (3, "Pling")
      (5, "Plang")
      (7, "Plong") ]
    |> List.fold
        (fun a (v, n) ->
            match number % v with
            | 0 -> a + n
            | _ -> a)
        ""
    |> fun it ->
        match it.Length with
        | 0 -> number.ToString()
        | _ -> it