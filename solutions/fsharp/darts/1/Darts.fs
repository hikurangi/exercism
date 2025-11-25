module Darts

let score (x: double) (y: double): int =
    let d = pown x 2 + pown y 2

    if d <= 1. then 10
    elif d <= 25. then 5
    elif d <= 100. then 1
    else 0
