open System
open Microsoft.Owin.Hosting
open Owin
open System.Threading.Tasks
open System.Diagnostics

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

