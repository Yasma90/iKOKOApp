#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["iKOKO.API/iKOKO.API.csproj", "iKOKO.API/"]
RUN dotnet restore "iKOKO.API/iKOKO.API.csproj"
COPY . .
WORKDIR "/src/iKOKO.API"
RUN dotnet build "iKOKO.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "iKOKO.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "iKOKO.API.dll"]