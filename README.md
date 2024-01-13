# OrderAccumulator

This is a C# Entity Framework API, built in order to store / calculate exposure of stock orders. The API is meant to be a backend to
the Order Generator Angular App, and has a complete CRUD of the orders, although they're not all used in frontend.

## How to use

The simplest way to test the API is by having Visual Studio Community, where it was built, you can simple clone the repository:

> git clone https://github.com/williamguilhermesouza/OrderAccumulator.git

Then import it o Visual Studio Community and run the API. 

If you have an IIS Server, with a Microsoft SQL Server you can run it locally, just create the database DB_OrderAccumulator, with user william and pass teste123,
run the migrations and you can run the app, the configurations of the database, if you want to change it, are in appsettings.json.

After this setup, you can run the Backend with:

> dotnet run --project .\OrderAccumulator\

Also, I'm sending a dockerfile, so you could create a docker image with:

> docker build -t OrderAccumulator .

And run with:

> docker run -dp 127.0.0.1:5279:5279 OrderAccumulator