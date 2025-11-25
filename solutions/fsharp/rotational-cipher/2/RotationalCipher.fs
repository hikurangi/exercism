module RotationalCipher


let rotateCharacterFrom letterA shiftKey character = (int character - int letterA + shiftKey) % 26 + int letterA |> char
let rotate shiftKey = String.map (function
        | c when System.Char.IsLower c -> rotateCharacterFrom 'a' shiftKey c
        | c when System.Char.IsUpper c -> rotateCharacterFrom 'A' shiftKey c
        | c -> c)
