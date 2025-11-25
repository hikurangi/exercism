module ArmstrongNumbers

let isArmstrongNumber number =
    number = Seq.fold (fun s c -> s + pown (int c - int '0') (string number).Length) 0 (string number)
