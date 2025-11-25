module Accumulate

let accumulate (func: 'a -> 'b) (input: 'a list): 'b list =
    let rec iterate acc =
        function
        | [] -> acc
        | h :: t -> iterate (func h :: acc) t

    iterate [] input |> List.rev
