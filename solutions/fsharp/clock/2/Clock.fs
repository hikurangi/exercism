module Clock

let dayInMinutes = 1440

let getRemainder a b = b % a

let normalize =
    function
    | m when m < 0 -> m + dayInMinutes
    | m -> m

let create hours minutes =
    (hours * 60 + minutes)
    |> getRemainder dayInMinutes
    |> normalize

let add minutes clock = create 0 (clock + minutes)

let subtract minutes clock = create 0 (clock - minutes)

let display clock =
    System.Math.DivRem(clock, 60)
    ||> sprintf "%02i:%02i"