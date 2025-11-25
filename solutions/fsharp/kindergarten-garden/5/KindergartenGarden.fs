module KindergartenGarden

type Plant =
    | Radishes
    | Clover
    | Grass
    | Violets

let plants diagram student =
    diagram
    |> string
    |> (fun it -> it.Split())
    |> Seq.collect (
        Seq.chunkBySize 2
        >> Seq.item (((student |> string).[0] |> int) - int 'A')
        >> Seq.map
            (function
            | 'R' -> Radishes
            | 'C' -> Clover
            | 'G' -> Grass
            | 'V' -> Violets
            | _ -> failwith "Invalid plant type specified")
    )
    |> List.ofSeq
