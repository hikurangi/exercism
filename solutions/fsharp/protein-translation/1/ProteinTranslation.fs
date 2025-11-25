module ProteinTranslation

let codonToProtein =
    function
    | "AUG" -> "Methionine"
    | "UUU" | "UUC" -> "Phenylalanine"
    | "UUA" | "UUG" -> "Leucine"
    | "UCU" | "UCC" | "UCA" | "UCG" -> "Serine"
    | "UAU" | "UAC" -> "Tyrosine"
    | "UGU" | "UGC" -> "Cysteine"
    | "UGG" -> "Tryptophan"
    | _ -> failwith "Invalid codon supplied"

let containsStopCodon c = Seq.contains c [ "UAA"; "UAG"; "UGA" ]

let proteins rna =
    let rec translate translated =
        function
        | [] -> translated
        | h :: _t when (containsStopCodon h) -> translated
        | h :: t -> translate (translated @ [ codonToProtein h ]) t

    let sequence =
        rna
        |> Seq.chunkBySize 3
        |> Seq.map ((Seq.map string) >> String.concat "")
        |> List.ofSeq

    translate [] sequence
