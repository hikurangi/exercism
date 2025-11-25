module Gigasecond
open System

let gigasecond = float 1000000000

let add (beginDate: DateTime) = beginDate.AddSeconds gigasecond