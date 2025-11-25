module GradeSchool

type School = Map<int, string list>

let empty = Map.empty

let add student grade school =
    school
    |> Map.change
        grade
        (function
        | None -> [ student ] |> Some
        | Some (l) -> student :: l |> List.sort |> Some)

let roster school =
    school |> Map.fold (fun s _k v -> s @ v) []

let grade number school =
    school
    |> Map.tryFind number
    |> Option.defaultValue []
