module AnnalynsInfiltration

let canFastAttack knightIsAwake = not knightIsAwake

let canSpy knightIsAwake archerIsAwake prisonerIsAwake = knightIsAwake || archerIsAwake || prisonerIsAwake

let canSignalPrisoner archerIsAwake prisonerIsAwake = prisonerIsAwake && not archerIsAwake

let canFreePrisoner knightIsAwake archerIsAwake prisonerIsAwake petDogIsPresent = match (knightIsAwake, archerIsAwake, prisonerIsAwake, petDogIsPresent) with
  | (true, true, true, true) 
  | (true, true, true, false)
  | (false, true, false, false)
  | (false, true, false, true)
  | (true, false, false, false)
  | (false, true, true, true)
  | (false, true, true, false)
  | (true, false, true, false)
  | (true, true, false, true)
  | (true, true, false, false)
  | (false, false, false, false) -> false
  | (false, false, false, true)
  | (false, false, true, true)
  | (false, false, true, false)
  | (true, false, false, true)
  | (true, false, true, true) -> true
