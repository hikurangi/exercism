module ArmstrongNumbers

let isArmstrongNumber number =
    match number, (string number).Length with
    | 0, _ -> true
    | _, 1 -> true
    | n, l ->
        n = (n
             |> string
             |> Seq.fold (fun s c -> s + pown (int c - int '0') l) 0)
