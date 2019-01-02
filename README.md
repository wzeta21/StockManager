## Start working with asp.net core 2.1
    1. Install SDK .net core 2.1 or higher
    2. Open the project with vscode or another IDE
    3. run: dotnet restore <- this installs needed libraries

## Generate database

To generate database follow this steps
    1.  dotnet ef migrations add StockDB
    2.  dotnet ef database update

## Executing / building
* To build project: dotnet build
* To run project: dotnet run


## compiling / publishing project:
To publish and release follow the next steps, according to your OS
- dotnet publish -c Release -r ubuntu.16.04-x64 <- for ubuntu
- dotnet publish -c Release -r win7-x86 <- for windows 7 x86