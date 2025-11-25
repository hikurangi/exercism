module Isogram
open System

let isIsogram (str: string): bool =
    str
    |> Seq.map Char.ToLowerInvariant
    |> Seq.countBy id
    |> Seq.exists (fun (k, v) -> ((v > 1) && Char.IsLetter k))
    |> not
