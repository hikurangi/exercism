module House

let private subjects =
    [ "house that Jack built."
      "malt that lay in"
      "rat that ate"
      "cat that killed"
      "dog that worried"
      "cow with the crumpled horn that tossed"
      "maiden all forlorn that milked"
      "man all tattered and torn that kissed"
      "priest all shaven and shorn that married"
      "rooster that crowed in the morn that woke"
      "farmer sowing his corn that kept"
      "horse and the hound and the horn that belonged to" ]

let recite startVerse endVerse : string list =

    let rec verse v i =
        if i > -1 then
            verse (v + " the " + subjects.[i]) (i - 1)
        else
            v

    [ startVerse - 1 .. endVerse - 1 ]
    |> Seq.map (verse "This is")
    |> List.ofSeq
