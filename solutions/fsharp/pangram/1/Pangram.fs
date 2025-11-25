module Pangram

open System

let alphabet = Set.ofList [ 'a' .. 'z' ]

let isPangram (input: string): bool =
    input
      |> Seq.toList
      |> List.map Char.ToLower
      |> Set.ofList
      |> fun inputLetters -> alphabet - inputLetters
      |> fun remainingLetters -> remainingLetters.Count = 0