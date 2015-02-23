open System
open Microsoft.Owin.Hosting
open Owin
open System.Threading.Tasks
open Nancy
open Nancy.Responses
open Nancy.Responses.Negotiation
open Fancy
open System.Diagnostics


type HomeModule() as this =
    inherit NancyModule()
    do fancy this {
        get "/" (
            fun () -> 
        fancyAsync {       
            Debugger.Break()  
            return "Hello world"}
        )
    }


[<EntryPoint>]
let main argv = 
    let options = StartOptions()
    options.ServerFactory <- "Nowin"
    let port = 8080
    options.Port <- Nullable(port)
    let startup (app: IAppBuilder) =
        app.UseNancy() |> ignore
        ()
    use server = WebApp.Start(options, startup)
    
    printfn "Listening on port %d" port
    Console.ReadLine() |> ignore
    0

