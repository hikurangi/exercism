module ErrorHandling

let handleErrorByThrowingException () = failwith "Exception!"

let handleErrorByReturningOption (input: string) =
    match System.Int32.TryParse input with
    | true, n -> Some n
    | false, _ -> None

let handleErrorByReturningResult (input: string) =
    match System.Int32.TryParse input with
    | true, n -> Ok n
    | false, _ -> Error "Could not convert input to integer"

let bind switchFunction =
    function
    | Error e -> Error e
    | Ok e -> switchFunction e

let cleanupDisposablesWhenThrowingException (resource: System.IDisposable) =
    resource.Dispose()
    failwith "Resource disposed!"
