module Meetup

open System

type Week =
    | First
    | Second
    | Third
    | Fourth
    | Last
    | Teenth

let finderPipeline day (finder: (DateTime -> bool) -> seq<DateTime> -> option<DateTime>) daysOfMonth =
    daysOfMonth
    |> finder (fun d -> d.DayOfWeek = day)
    |> (function
    | Some d -> d
    | None -> failwith "Day not found!")

let findDay week day (daysOfMonth: seq<DateTime>) =
    match week with
    | First ->
        daysOfMonth
        |> Seq.take 7
        |> finderPipeline day Seq.tryFind
    | Second ->
        daysOfMonth
        |> Seq.skip 7
        |> Seq.take 7
        |> finderPipeline day Seq.tryFind
    | Third ->
        daysOfMonth
        |> Seq.skip 14
        |> Seq.take 7
        |> finderPipeline day Seq.tryFind
    | Fourth ->
        daysOfMonth
        |> Seq.skip 21
        |> Seq.take 7
        |> finderPipeline day Seq.tryFind
    | Last -> daysOfMonth |> finderPipeline day Seq.tryFindBack
    | Teenth ->
        daysOfMonth
        |> Seq.skip 12
        |> Seq.take 7
        |> finderPipeline day Seq.tryFind

let meetup year month week dayOfWeek : DateTime =
    (year, month)
    |> DateTime.DaysInMonth
    |> (fun d -> [ 1 .. d ])
    |> Seq.map (fun d -> (year, month, d) |> DateTime)
    |> findDay week dayOfWeek
