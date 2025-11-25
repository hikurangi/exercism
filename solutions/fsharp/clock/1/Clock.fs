module Clock

let create hours minutes =
    let totalInMinutes = (hours * 60) + minutes

    let totalWholeHours =
        (float totalInMinutes / 60.) |> floor |> int

    let rolledHours =
        match totalWholeHours % 24 with
        | h when h < 0 -> h + 24
        | h -> h

    let rolledMinutes =
        match totalInMinutes - (totalWholeHours * 60) with
        | m when m < 0 -> m + 60
        | m -> m

    (rolledHours, rolledMinutes)

let add minutes clock =
    (fst clock, snd clock + minutes) ||> create

let subtract minutes clock =
    (fst clock, snd clock - minutes) ||> create

let display clock =
    (fst clock, snd clock) ||> sprintf "%02i:%02i"
