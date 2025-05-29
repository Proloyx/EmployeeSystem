FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["./EmployeeSystem.csproj", "./"]
RUN dotnet restore "./EmployeeSystem.csproj"
COPY . .
RUN dotnet build "./EmployeeSystem.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./EmployeeSystem.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "EmployeeSystem.dll"]