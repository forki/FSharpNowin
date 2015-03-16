module Modules 
    open ServiceStack.OrmLite
    open Nancy
    open Fancy
    open ServiceStack.Data
   
    type HomeModule(db:IDbConnectionFactory) as this =
        inherit NancyModule()
        do fancy this {
            get "/" (fun () -> fancyAsync {
                //use conn = db.Open()                
                return this.View.["Home"]
            })
        }