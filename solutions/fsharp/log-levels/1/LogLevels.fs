module LogLevels

let level = function
  | "[WARNING]" -> "warning"
  | "[ERROR]" -> "error"
  | "[INFO]" -> "info"
  | s -> s

let re = function
  | "[WARNING]" -> "(warning)"
  | "[ERROR]" -> "(error)"
  | "[INFO]" -> "(info)"
  | s -> s

let format (formatter: string -> string) (logline: string) = logline.Split(':') |> Seq.map ((fun s -> s.Trim()) >> formatter)

let message = format level >> Seq.last

let logLevel = format level >> Seq.head

let reformat = format re >> Seq.rev >> Seq.reduce (fun acc s -> acc + " " + s)
