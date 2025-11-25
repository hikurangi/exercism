module Grains

let square (n: int): Result<uint64, string> =
    match n with
     | _ when n < 1 || n > 64 -> Error "square must be between 1 and 64"
     | _ -> Ok(pown<uint64> 2UL (n - 1))

let total: Result<uint64, string> = Ok 18446744073709551615UL // square 64
