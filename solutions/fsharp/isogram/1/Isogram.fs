module Isogram

let isIsogram (str: string): bool =
    str
    |> Seq.map System.Char.ToLowerInvariant
    |> Seq.groupBy id
    |> Seq.exists (fun (k, v) -> (((Seq.length v) > 1) && System.Char.IsLetter k))
    |> not
