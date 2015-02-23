module Bootstrapper

open Nancy
open Nancy.TinyIoc
open Nancy.Bootstrapper
open ServiceStack.Data
open Datalayer

type Bootstrapper() =
    inherit DefaultNancyBootstrapper()
    override x.ApplicationStartup(container:TinyIoCContainer, pipelines:IPipelines) = 
        StaticConfiguration.DisableErrorTraces <- false
        container.Register<IDbConnectionFactory>(factory) |> ignore
        base.ApplicationStartup(container,pipelines)
        ignore()