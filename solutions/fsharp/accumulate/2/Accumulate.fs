module Accumulate

let cons x y = x :: y

let accumulate (func: 'a -> 'b) (input: 'a list): 'b list =
    let rec iterate acc =
        function
        | [] -> acc []
        | h :: t -> iterate ((cons (func h)) >> acc) t

    iterate id input
