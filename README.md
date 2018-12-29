## Empezar a trabajar con asp.net core 2
    1. Instalar SDK .net core 2.1 o superio
    2. Abrir el proyecto con vscode u otro IDE
    3. ejecutar: dotnet restore <- esto instala las librerias necesarias

## Generar la base de datos

Para generar la base de datos siga los siguientes pasos

    1.  dotnet ef migrations add chambareporterdb
    2.  dotnet ef database update

## Ejecucíon/construcción
* para construir el proyecto: dotnet build
* para ejecutar el proyecto: dotnet run


## compilar/publicar proyecto:
Para publicar un release siga los siguientes pasos, segun su sitema operativo
- dotnet publish -c Release -r ubuntu.16.04-x64 <- para ubuntu
- dotnet publish -c Release -r win7-x86