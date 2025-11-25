module CollatzConjecture

let rec countSteps (number: int) (count: int): int option =
    match (number, count) with
    | (n, _) when n < 1 -> None 
    | (1, c) -> Some c
    | (n, c) when n % 2 = 0 -> countSteps (n / 2) (c + 1)
    | (n, c) -> countSteps (3 * n + 1) (c + 1)

let steps (number: int): int option = countSteps number 0
