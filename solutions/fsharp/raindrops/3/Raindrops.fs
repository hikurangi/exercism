module Raindrops

let nameDrop divisor divisorName (number, existingName) =
    let newName =
        match existingName with
        | Some n -> Some(n + divisorName)
        | _ -> Some divisorName

    if number % divisor = 0 then
        (number, newName)
    else
        (number, existingName)

let unwrapDrop (number, name) =
    name |> Option.defaultValue (number.ToString())

let convert (number: int): string =
    (number, None)
    |> nameDrop 3 "Pling"
    |> nameDrop 5 "Plang"
    |> nameDrop 7 "Plong"
    |> unwrapDrop
