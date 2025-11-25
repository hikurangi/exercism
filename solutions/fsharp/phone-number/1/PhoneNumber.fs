module PhoneNumber

open System
open System.Text.RegularExpressions

let sanitize (pN: Result<string, string>) =
    match pN with
    | Ok n -> Ok(Regex.Replace(n, "[^0-9]", ""))
    | _ -> pN

let wrap s = Ok s

let matches p s = Regex.Match(s, p).Success

let validateInput (pN: Result<string, string>) =
    match pN with
    | Ok n when n |> matches "[a-zA-Z]" -> Error "letters not permitted"
    | Ok n when n |> matches "[,\?'\":;!]" -> Error "punctuations not permitted"
    | _ -> pN

let validateLength (pN: Result<string, string>) =
    match pN with
    | Ok n when n.Length < 10 -> Error "incorrect number of digits"
    | Ok n when n.Length > 11 -> Error "more than 11 digits"
    | _ -> pN

let validateCountryCode (pN: Result<string, string>) =
    match pN with
    | Ok n when n.Length = 11 && Seq.head n <> '1' -> Error "11 digits must start with 1"
    | _ -> pN

let trimCountryCode (pN: Result<string, string>) =
    match pN with
    | Ok n when n.Length = 11 && n.[0] = '1' ->
        n
        |> Seq.tail
        |> Seq.fold (fun acc c -> acc + c.ToString()) ""
        |> Ok
    | _ -> pN

let validatePositions (pN: Result<string, string>) =
    match pN with
    | Ok n when n.[0] = '0' -> Error "area code cannot start with zero"
    | Ok n when n.[0] = '1' -> Error "area code cannot start with one"
    | Ok n when n.[3] = '0' -> Error "exchange code cannot start with zero"
    | Ok n when n.[3] = '1' -> Error "exchange code cannot start with one"
    | _ -> pN

let parse (pN: Result<string, string>) =
    match pN with
    | Ok n ->
        match UInt64.TryParse(n) with
        | (false, _) -> Error(sprintf "could not parse value %A" n)
        | (true, p) -> Ok p
    | Error e -> Error e

let clean input: Result<uint64, string> =
    input
    |> wrap
    |> validateInput
    |> sanitize
    |> validateLength
    |> validateCountryCode
    |> trimCountryCode
    |> validatePositions
    |> parse
