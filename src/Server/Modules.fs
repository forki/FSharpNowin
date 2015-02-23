module Modules 
    open Nancy
    open Nancy.Responses
    open Nancy.Responses.Negotiation
    open Fancy

    type HomeModule() as this =
        inherit NancyModule()
        do fancy this {
            get "/" (fun () -> fancyAsync {
                return "Hello world1"
            })
        }