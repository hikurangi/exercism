module Raindrops

let nameDrop divisor divisorName (number, fullName) =
    if number % divisor = 0 then
        (number, fullName + divisorName)
    else
        (number, fullName)

let unwrapDrop (number, fullName) =
    if String.length fullName > 0 then
        fullName
    else
        number.ToString()

let convert (number: int): string =
    (number, "")
    |> nameDrop 3 "Pling"
    |> nameDrop 5 "Plang"
    |> nameDrop 7 "Plong"
    |> unwrapDrop
