module Grains

let square (n: int): Result<uint64, string> =
    match n with
     | _ when n < 1 || n > 64 -> "square must be between 1 and 64" |> Error
     | _ -> pown 2UL (n - 1) |> Ok

let total: Result<uint64, string> = Ok 18446744073709551615UL // square 64
