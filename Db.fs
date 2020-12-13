namespace SuaveAPIRest

open System.Collections.Generic
open Microsoft.AspNetCore.Mvc
open Microsoft.EntityFrameworkCore
open System.Linq;

[<Route("/")>]
[<ApiController>]
type ToDoItemsController private () = 
    inherit ControllerBase()
    
    
    [<Route("search")>]
    [<HttpPost>]
    member this.Post() =
        printfn "Hello, HEre?"

    