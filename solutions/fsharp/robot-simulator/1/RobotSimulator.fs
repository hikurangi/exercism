module RobotSimulator

type Direction =
    | North
    | East
    | South
    | West

type Position = int * int

type Robot =
    { Direction: Direction
      Position: Position }

let create direction position =
    { Direction = direction
      Position = position }

let turnRight r =
    match r.Direction with
    | North -> { r with Direction = East }
    | East -> { r with Direction = South }
    | South -> { r with Direction = West }
    | West -> { r with Direction = North }

let turnLeft r =
    match r.Direction with
    | North -> { r with Direction = West }
    | West -> { r with Direction = South }
    | South -> { r with Direction = East }
    | East -> { r with Direction = North }

let advance r =
    match r.Direction with
    | North ->
        { r with
              Position = (fst r.Position, snd r.Position + 1) }
    | East ->
        { r with
              Position = (fst r.Position + 1, snd r.Position) }
    | South ->
        { r with
              Position = (fst r.Position, snd r.Position - 1) }
    | West ->
        { r with
              Position = (fst r.Position - 1, snd r.Position) }

let convertInstruction =
    function
    | 'A' -> advance
    | 'L' -> turnLeft
    | 'R' -> turnRight
    | i -> failwith $"Invalid instruction '{i}'"

let move instructions robot =
    instructions
    |> Seq.fold (fun r f -> r |> convertInstruction f) robot
