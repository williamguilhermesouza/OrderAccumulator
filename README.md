# OrderAccumulator

![order-accumulator](https://raw.githubusercontent.com/williamguilhermesouza/OrderAccumulator/master/order-accumulator.gif)

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

Also, I'm sending a dockerfile and a docker-compose file, so you could create a docker image with:

> docker build -t orderaccumulator .

And run with:

> docker-compose up

Just remember to uncomment the docker connection string at appsettings.json, and comment the local one. The migrations are run automatically at startup.

