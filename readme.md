# Sales Manager
 
The sales manager is a Blazor application for managing orders.
 
## Installation
1. Install [.NET 7](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
2. Install [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
3) Install dotnet tool
```
dotnet tool install --global dotnet-ef
```
 
## Usage
Run the following commands:
```cmd
dotnet restore .
dotnet ef database update --project SalesManager\Server
dotnet run -c Release --project SalesManager\Server
```
Now hit the browser with the listening port (Ex: [localhost](http://localhost:5219))