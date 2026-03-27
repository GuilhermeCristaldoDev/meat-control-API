FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY meat-console-API/meat-console-API/ .
RUN dotnet restore meat-control-API.csproj
RUN dotnet publish meat-control-API.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "meat-control-API.dll"]