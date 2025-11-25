module CollatzConjecture

let rec countSteps count =
    function
    | n when n < 1 -> None
    | 1 -> Some count
    | n when n % 2 = 0 -> countSteps (count + 1) (n / 2)
    | n -> countSteps (count + 1) (3 * n + 1)

let steps number = countSteps 0 number
