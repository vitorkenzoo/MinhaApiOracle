# Estágio 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia o .csproj e restaura
COPY ["MinhaApiOracle.csproj", "."]
RUN dotnet restore "./MinhaApiOracle.csproj"

# Copia o resto e faz o build
COPY . .
WORKDIR "/src/."
RUN dotnet build "MinhaApiOracle.csproj" -c Release -o /app/build

# Estágio 2: Publish
FROM build AS publish
RUN dotnet publish "MinhaApiOracle.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Estágio 3: Final
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "MinhaApiOracle.dll"]