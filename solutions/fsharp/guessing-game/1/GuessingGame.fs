module GuessingGame

let reply =
    function
    | g when g < 41 -> "Too low"
    | g when g = 41 || g = 43 -> "So close"
    | g when g > 43 -> "Too high"
    | _ -> "Correct"
