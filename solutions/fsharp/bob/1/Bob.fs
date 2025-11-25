module Bob

open System.Text.RegularExpressions

let isShouting s =
    let hasCapitals =
        Regex.Match(s, "[A-Z]") |> fun r -> r.Success

    let hasLowerCase =
        Regex.Match(s, "[a-z]") |> fun r -> r.Success

    hasCapitals && not hasLowerCase

let isQuestion s =
    Regex.Match(s, "\?$") |> fun r -> r.Success

let response (statement: string) =
    match statement.Trim() with
    | s when isShouting s && isQuestion s -> "Calm down, I know what I'm doing!"
    | s when isShouting s -> "Whoa, chill out!"
    | s when isQuestion s -> "Sure."
    | "" -> "Fine. Be that way!"
    | _ -> "Whatever."
