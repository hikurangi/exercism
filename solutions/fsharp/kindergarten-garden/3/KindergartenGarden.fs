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

let filterByIndices indices l =
    [ for i in indices do
          yield l |> Seq.item i ]

let plants (diagram: string) student =

    let studentIndices =
        [ List.findIndex ((=) student) students * 2
          (List.findIndex ((=) student) students * 2) + 1 ]

    diagram.Split()
    |> Seq.collect (
        filterByIndices studentIndices
        >> Seq.map getPlantByInitial
    )
    |> List.ofSeq
