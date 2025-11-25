module PerfectNumbers

type Classification =
    | Perfect
    | Abundant
    | Deficient

let classify =
    function
    | n when n < 1 -> None
    | n ->
        [ 1 .. n / 2 ]
        |> Seq.filter (fun i -> n % i = 0)
        |> Seq.sum
        |> (function
        | s when s < n -> Deficient
        | s when s > n -> Abundant
        | s when s = n -> Perfect
        | s -> failwith $"Miraculously invalid number {s}")
        |> Some
