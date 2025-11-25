module GuessingGame

let private n = 42

let reply =
    function
    | g when g < n - 1 -> "Too low"
    | g when g = n - 1 || g = n + 1 -> "So close"
    | g when g > n + 1 -> "Too high"
    | _ -> "Correct"
