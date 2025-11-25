module ArmstrongNumbers

let isArmstrongNumber number =
    number = (number
              |> string
              |> Seq.fold (fun s c -> s + pown (int c - int '0') (string number).Length) 0)