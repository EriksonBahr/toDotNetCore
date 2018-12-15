FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ToDo.API.csproj .
RUN dotnet restore ToDo.API.csproj
COPY . .
RUN dotnet build ToDo.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish ToDo.API.csproj -c Release -o /app

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ToDo.API.dll"]
