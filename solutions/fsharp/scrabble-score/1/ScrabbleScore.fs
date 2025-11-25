module ScrabbleScore

let mapLetter c =
    match System.Char.ToUpperInvariant c with
    | 'A'
    | 'E'
    | 'I'
    | 'O'
    | 'U'
    | 'L'
    | 'N'
    | 'R'
    | 'S'
    | 'T' -> 1
    | 'D'
    | 'G' -> 2
    | 'B'
    | 'C'
    | 'M'
    | 'P' -> 3
    | 'F'
    | 'H'
    | 'V'
    | 'W'
    | 'Y' -> 4
    | 'K' -> 5
    | 'J'
    | 'X' -> 8
    | 'Q'
    | 'Z' -> 10

let score word = word |> Seq.fold (fun acc it -> acc + mapLetter it) 0
