module RestApi

open Newtonsoft.Json
open Newtonsoft.Json.Serialization

let snakeCaseContractResolver = DefaultContractResolver()
snakeCaseContractResolver.NamingStrategy <- SnakeCaseNamingStrategy()
let serializerSettings = JsonSerializerSettings()
serializerSettings.ContractResolver <- snakeCaseContractResolver

let deserialize<'a> s =
    JsonConvert.DeserializeObject<'a>(s, serializerSettings)

let serialize o =
    JsonConvert.SerializeObject(o, serializerSettings)

type Ledger = Map<string, double>
type User =
    { Name: string
      Owes: Ledger
      OwedBy: Ledger
      Balance: double }

type AddUsersDTO = { User: string }
type GetUsersDTO = { Users: string seq }
type DatabaseDTO = { Users: User seq }

type IOUDTO =
    { Lender: string
      Borrower: string
      Amount: double }

type Application(database: DatabaseDTO) =
    let mutable _users = database.Users

    member this.InitializeUser(user: AddUsersDTO) =
        { Name = user.User
          Owes = Map.empty
          OwedBy = Map.empty
          Balance = 0.0 }

    member this.GetUsers(search: GetUsersDTO) =
        _users
        |> Seq.filter (fun u -> search.Users |> Seq.contains u.Name)
        |> (fun u -> { Users = u })

    member this.GetAllUsers = { Users = _users }

    member this.GetUser(search: string) =
        _users
        |> Seq.tryFind (fun u -> search = u.Name)
        |> (function
        | Some u -> u
        | None -> failwith "User not found")

    member this.GetUpdatedUsers(additionalUsers: User seq) =
        _users
        |> Seq.filter
            (fun u ->
                additionalUsers
                |> Seq.exists (fun u' -> u.Name = u'.Name)
                |> not)
        |> Seq.append additionalUsers

    member this.UpdateUsers(updatedUsers: User seq) = _users <- updatedUsers

    member this.ResolveIOU(iou: IOUDTO) : DatabaseDTO =
        let defaultToZero v = defaultArg v 0.0

        let updateUser existingProtagonist protagonistTotal antagonistName balance =
            { existingProtagonist with
                  Balance = balance
                  Owes =
                      if protagonistTotal < 0.0 then
                          existingProtagonist.Owes.Add(antagonistName, protagonistTotal |> abs)
                      else
                          antagonistName |> existingProtagonist.Owes.Remove
                  OwedBy =
                      if protagonistTotal > 0.0 then
                          existingProtagonist.OwedBy.Add(antagonistName, protagonistTotal)
                      else
                          antagonistName |> existingProtagonist.OwedBy.Remove }

        let getUserTotal protagonist antagonist amount =
            (antagonist.Name
             |> protagonist.OwedBy.TryFind
             |> defaultToZero)
            - (antagonist.Name |> protagonist.Owes.TryFind |> defaultToZero) + amount

        let amount = iou.Amount

        let lenderUser = iou.Lender |> this.GetUser
        let borrowerUser = iou.Borrower |> this.GetUser

        let updatedLenderUser =
            updateUser
                lenderUser
                (getUserTotal lenderUser borrowerUser amount)
                borrowerUser.Name
                (lenderUser.Balance + amount)

        let updatedBorrowerUser =
            updateUser
                borrowerUser
                (getUserTotal borrowerUser lenderUser (-amount))
                lenderUser.Name
                (borrowerUser.Balance - amount)

        { Users =
              [ updatedLenderUser
                updatedBorrowerUser ]
              |> Seq.sortBy (fun u -> u.Name) }

type RestApi(database) =
    let _app =
        database
        |> deserialize<DatabaseDTO>
        |> Application

    member this.Get(url: string) =
        match url with
        | "/users" -> _app.GetAllUsers |> serialize
        | _ -> "404"

    member this.Get(url: string, payload: string) =
        match url with
        | "/users" ->
            payload
            |> deserialize<GetUsersDTO>
            |> _app.GetUsers
            |> serialize
        | _ -> "404"

    member this.Post(url: string, payload: string) =
        match url with
        | "/add" ->
            payload
            |> deserialize<AddUsersDTO>
            |> _app.InitializeUser
            |> serialize
        | "/iou" ->
            payload
            |> deserialize<IOUDTO>
            |> _app.ResolveIOU
            |> serialize
        | _ -> "404"
