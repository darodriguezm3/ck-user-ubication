# 1. Usar la imagen base de .NET SDK para construir la aplicación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# 2. Copiar los archivos del proyecto y restaurar las dependencias
COPY *.csproj ./
RUN dotnet restore

# 3. Copiar el resto de los archivos y construir la aplicación
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# 4. Usar una imagen base ligera de .NET ASP.NET Core Runtime para ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# 5. Copiar los archivos compilados desde el paso anterior
COPY --from=build /app/publish .

# 6. Establecer el puerto de escucha y la variable de entorno para Back4App
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

# 7. Comando de inicio para correr la aplicación
ENTRYPOINT ["dotnet", "myapp.dll"]
