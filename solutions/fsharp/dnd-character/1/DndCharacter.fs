module DndCharacter

open System

let modifier x =
    ((decimal x - 10m) / 2m) |> floor |> int

let ability () =
    let random = Random()
    let roll () = random.Next(1, 6)

    [ for _ in 1 .. 4 -> roll () ]
    |> List.sortDescending
    |> List.take 3
    |> List.sum

type Character =
    { Strength: int
      Dexterity: int
      Constitution: int
      Intelligence: int
      Wisdom: int
      Charisma: int
      Hitpoints: int }

let createCharacter () =
    let constitution = ability ()
    let constitutionModifier = modifier constitution

    { Strength = ability ()
      Dexterity = ability ()
      Constitution = constitution
      Intelligence = ability ()
      Wisdom = ability ()
      Charisma = ability ()
      Hitpoints = 10 + constitutionModifier }
