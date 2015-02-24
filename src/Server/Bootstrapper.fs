module Bootstrapper

open Nancy
open Nancy.TinyIoc
open Nancy.Bootstrapper
open ServiceStack.Data
open Datalayer
open Nancy.Conventions

type Bootstrapper() =
    inherit DefaultNancyBootstrapper()

    override x.ApplicationStartup(container:TinyIoCContainer, pipelines:IPipelines) = 
        StaticConfiguration.DisableErrorTraces <- false
        container.Register<IDbConnectionFactory>(factory) |> ignore
        base.ApplicationStartup(container,pipelines)

    override x.ConfigureConventions(conventions:NancyConventions) =
        conventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("Scripts",@"Scripts"))
        conventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("fonts",@"fonts"))
        base.ConfigureConventions(conventions)