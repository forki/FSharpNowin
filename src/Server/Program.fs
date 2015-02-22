open System
open Microsoft.Owin.Hosting
open Owin
open System.Threading.Tasks



[<EntryPoint>]
let main argv = 

    let options = StartOptions()
    options.ServerFactory <- "Nowin"
    options.Port <- Nullable(8080)
    let startup (app: IAppBuilder) =
        
        ()
    use server = WebApp.Start(options, startup)

    Console.ReadLine() |> ignore

    printfn "%A" argv
    0 // return an integer exit code
