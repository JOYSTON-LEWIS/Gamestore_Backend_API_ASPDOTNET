// TS-04:40-27:54: Additional Notes
// TS-04:40-27:54: appsettings.json is the Production JSON
// TS-04:40-27:54: appsettings.Development.json is the Development Environment JSON
// TS-04:40-27:54: launchSettings.json -> http and https code are for development purpose
// TS-04:40-27:54: ASPNETCORE_ENVIRONMENT defines that we are working in development environment
// TS-04:40-27:54: bin -> dll and assemblies
// TS-04:40-27:54: obj -> is where we will have intermediate files or compilation files

// TS-04:40-27:54: host of your application
// TS-04:40-27:54: implements http server for your application
using GameStore.Api.Data;
using GameStore.Api.Dtos;

// TS-04:40-27:54:
var builder = WebApplication.CreateBuilder(args);
// TS-04:40-27:54: builder related code here

// TS-01:44:41-01:57:53: defining connection string
// TS-01:44:41-01:57:53: connecting to sqllite is very simple just write Data Source= followed by the physical path into your database file
// TS-01:44:41-01:57:53: removed this configuration and moved it to the appsettings.json
// TS-01:44:41-01:57:53: var connString = "Data Source=GameStore.db";
// TS-01:44:41-01:57:53: replacing hardcoded connString to the following reference from appsettings.json.
// TS-01:44:41-01:57:53: builder then Configuration then get Connection String and the name of the key you provided in the appsettings.json
var connString = builder.Configuration.GetConnectionString("GameStore");

// TS-01:44:41-01:57:53: registering the service
// TS-01:44:41-01:57:53: Entity framework will read connString, create instance of GameStoreContext and pass in DbContextOptions<GameStoreContext> options that will contain all details of the connection string so that it can connect to database and map the entities to the table
// TS-01:44:41-01:57:53: for production environment we would have to keep these configuration data outside of this code for security concerns.
// TS-02:26:28-02:38:46: Here in the background something like this is happening : 
// TS-02:26:28-02:38:46: builder.Services.AddScoped<GameStoreContext>
// TS-02:26:28-02:38:46: Its getting registered here, anywhere in the code we can inject the instance and use its services
builder.Services.AddSqlite<GameStoreContext>(connString);


// TS-04:40-27:54: configurations code here
var app = builder.Build();

// TS-01:20:22-01:25:46: returning the http from the static class to program.cs 
// TS-01:20:22-01:25:46: which is the bootstrap of our dotnet application
app.MapGamesEndpoints();

// TS-03:18:16-03:38:39: returning the http responses for genres into our application
app.MapGenresEndpoints();

// TS-02:02:40-02:20:57: invoking the class function on startup
// TS-03:18:16-03:38:39: adding the await MigrateDbAsync function to make it asynchronous 
await app.MigrateDbAsync();

// TS-04:40-27:54:
app.Run();
