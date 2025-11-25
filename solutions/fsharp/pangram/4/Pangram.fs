module Pangram

let isPangram (input: string): bool =
    input
    |> Seq.map System.Char.ToLowerInvariant
    |> Set.ofSeq
    |> Set.isSubset (Set.ofList [ 'a' .. 'z' ])
