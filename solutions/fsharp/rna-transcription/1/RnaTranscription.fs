module RnaTranscription

let toRna (dna: string): string =
    dna
    |> String.map
        (fun char ->
            match char with
            | 'C' -> 'G'
            | 'G' -> 'C'
            | 'T' -> 'A'
            | 'A' -> 'U'
            | _ -> char)
