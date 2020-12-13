namespace SuaveRestApi.Rest
open Newtonsoft.Json
open Newtonsoft.Json.Serialization
open Suave.Web
open Suave
open Suave.Http
open Suave.Successful
open SuaveRestApi.Db
open Suave.Web
open Suave.Successful
open Suave.Http 
open System
open Akka.FSharp

[<AutoOpen>]

type RestResource<'a> = {
    GetAll : unit -> 'a seq
  }
module RestFul =
  let path incom =
    match incom with
    | "http://127.0.0.1:8080/" ->
        startWebServer defaultConfig (OK "Hello, Suave!")
    
  let JSON v =
    let jsonSerializerSettings = new JsonSerializerSettings()
    jsonSerializerSettings.ContractResolver <- new CamelCasePropertyNamesContractResolver()
    JsonConvert.SerializeObject(v, jsonSerializerSettings)
    |> OK
    >=> Writers.setMimeType "application/json; charset=utf-8"
   
  let rest resourceName resource =
    let resourcePath = "/" + resourceName
    let getAll = warbler (fun _ -> resource.GetAll () |> JSON)
    path resourcePath >=> GET >=> getAll