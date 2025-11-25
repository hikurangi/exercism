module SpaceAge

type Planet =
    | Earth
    | Mercury
    | Venus
    | Mars
    | Jupiter
    | Saturn
    | Uranus
    | Neptune

let yearInSeconds =
    function
    | Mercury -> 7_600_543.82
    | Venus -> 19_414_149.05
    | Earth -> 31_557_600.
    | Mars -> 59_354_032.69
    | Jupiter -> 374_355_659.1
    | Saturn -> 929_292_362.9
    | Uranus -> 2_651_370_019.0
    | Neptune -> 5_200_418_560.0

let age planet (seconds: int64) = float seconds / yearInSeconds planet