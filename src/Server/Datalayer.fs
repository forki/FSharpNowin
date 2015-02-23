module Datalayer
    open ServiceStack
    open ServiceStack.OrmLite

    let SqliteFileDb = "~/db.sqlite".MapAbsolutePath()
    let factory = OrmLiteConnectionFactory(SqliteFileDb, SqliteDialect.Provider)