open System
open Microsoft.Owin.Hosting
open Owin
open System.Threading.Tasks
open Nancy

let processor ctx c = None |> async.Return
    
type HomeModule() as this =
    inherit NancyModule()
    do this.Before.AddItemToEndOfPipeline(
                fun ctx c -> Async.StartAsTask(async {
                    let! res = processor ctx c
                    return match res with 
                                | Some x -> x
                                | None -> null
                }))
    do this.Get.["/"] <- (fun param -> 
                            "Hello world" :> obj)

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

