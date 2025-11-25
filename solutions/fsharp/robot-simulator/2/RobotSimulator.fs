module RobotSimulator

type Direction =
    | North
    | East
    | South
    | West

type Turn =
    | Left
    | Right

type Position = int * int

type Robot =
    { Direction: Direction
      Position: Position }

let create direction position =
    { Direction = direction
      Position = position }

let generateTurns direction =
    direction
    |> (function
    | Left -> [ North; West; South; East; North ]
    | Right -> [ North; East; South; West; North ])
    |> List.pairwise
    |> Map

let turn direction robot =
    { robot with
          Direction = (generateTurns direction).[robot.Direction] }

let advance robot =
    { robot with
          Position =
              match robot.Direction, robot.Position with
              | North, (x, y) -> (x, y + 1)
              | East, (x, y) -> (x + 1, y)
              | South, (x, y) -> (x, y - 1)
              | West, (x, y) -> (x - 1, y) }

let mapInstruction =
    function
    | 'A' -> advance
    | 'L' -> turn Left
    | 'R' -> turn Right
    | i -> failwith $"Invalid instruction '{i}'"

let move instructions robot =
    instructions
    |> Seq.map mapInstruction
    |> Seq.fold (|>) robot
