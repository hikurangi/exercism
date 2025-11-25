module Raindrops

let dropName divisor divisorName (number, fullName) =
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
    |> dropName 3 "Pling"
    |> dropName 5 "Plang"
    |> dropName 7 "Plong"
    |> unwrapDrop
