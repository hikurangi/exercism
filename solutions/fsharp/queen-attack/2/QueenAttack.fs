module QueenAttack

let create ((r, c): int * int) = r > -1 && c > -1 && r < 8 && c < 8

let canAttack (queen1: int * int) (queen2: int * int) =
    match (queen1, queen2) with
    | (q1, q2) when q1 = q2 -> failwith "Two pieces can't share a square."
    | ((r1, c1), (r2, c2)) when
        r1 = r2
        || c1 = c2
        || abs (r1 - r2) = abs (c1 - c2) -> true
    | _ -> false