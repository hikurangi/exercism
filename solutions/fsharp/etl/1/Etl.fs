module Etl

let folder state (k, v) =
    v
    |> List.map (fun c -> (System.Char.ToLowerInvariant c, k))
    |> List.append (Map.toList state)
    |> Map.ofList

let transform scoresWithLetters =
    scoresWithLetters
    |> Map.toSeq
    |> Seq.fold folder Map.empty
