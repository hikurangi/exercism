module KindergartenGarden

type Plant =
    | Radishes
    | Clover
    | Grass
    | Violets

let students =
    [ "Alice"
      "Bob"
      "Charlie"
      "David"
      "Eve"
      "Fred"
      "Ginny"
      "Harriet"
      "Ileana"
      "Joseph"
      "Kincaid"
      "Larry" ]

let getPlantByInitial =
    function
    | 'R' -> Radishes
    | 'C' -> Clover
    | 'G' -> Grass
    | 'V' -> Violets
    | _ -> failwith "Invalid plant type specified"

let plants (diagram: string) (student: string) =

    let fstIdx =
        List.findIndex (fun i -> i = student) students * 2
    let sndIdx = fstIdx + 1

    let row1 =
        diagram.Split([| '\n' |]).[0] |> List.ofSeq
    let row2 =
        diagram.Split([| '\n' |]).[1] |> List.ofSeq

    [ row1.[fstIdx]
      row1.[sndIdx]
      row2.[fstIdx]
      row2.[sndIdx] ]
    |> List.map getPlantByInitial