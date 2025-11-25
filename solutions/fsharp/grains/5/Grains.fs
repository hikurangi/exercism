module Grains

let square = function
    | n when n < 1 || n > 64 -> "square must be between 1 and 64" |> Error
    | n -> pown 2UL (n - 1) |> Ok

let total: Result<uint64, string> =
    [ 1 .. 64 ]
    |> Seq.fold (fun acc it -> acc + pown 2UL (it - 1)) 0UL
    |> Ok