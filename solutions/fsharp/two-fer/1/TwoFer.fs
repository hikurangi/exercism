module TwoFer

let twoFer (input: string option): string =
    let who =
        match input with
        | Some person -> person
        | None -> "you"

    sprintf "One for %s, one for me." who
