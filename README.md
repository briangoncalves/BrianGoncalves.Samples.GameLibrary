# BrianGoncalves.Samples.GameLibrary
In this application sample, I have a .NET Core WEBAPI server with a postgreSQL database (CRUD methods)

I have a client in VueJS and WebPack (eslint, es6 to es5, node package manager [npm])

I use Auth0 for authentication (facebook social connection)

To run the server in linux, you can execute the RunApp.sh from the folder GameLibrary\Server\bin\Release

To run the client, you can execute 'npm run dev' having node installed, which will start a development server and open the application

The Server must run in the port 22200 - 'http://localhost:22200'
The client must run in the port 8080 - 'http://localhost:8080'

For now only localhost and those ports access is allowed since that is configured in the Auth0 app


have a postgresql installed, configure the GameLibraryConnection under appsettings.json in the server folder
The default configuration is:
User ID=postgres;Password=348934;Host=localhost;Port=5432;Database=GameLibrary;Pooling=true

Note that the database name used is 'GameLibrary'

Create the following table in postgreSQL
CREATE TABLE "Games"(
	"Id" Serial,
    "Name" varchar,
    "Publisher" varchar,
    "Category" varchar,
    "CreatedOn" timestamp
)
