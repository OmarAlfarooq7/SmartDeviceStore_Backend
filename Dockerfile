# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["SmartDeviceStore.API.csproj", "./"]
RUN dotnet restore "./SmartDevicesStore.API.csproj"
COPY . .
RUN dotnet publish "./SmartDevicesStore.API.csproj" -c Release -o /app/publish

# Stage 2: Final image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SmartDevicesStore.API.dll"]