# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# نسخ ملف المشروع من المجلد الفرعي إلى بيئة البناء
COPY ["SmartDevicesStore.API/SmartDevicesStore.API.csproj", "SmartDevicesStore.API/"]
RUN dotnet restore "SmartDevicesStore.API/SmartDevicesStore.API.csproj"

# نسخ كل الكود
COPY . .
WORKDIR "/src/SmartDevicesStore.API"
RUN dotnet publish "SmartDevicesStore.API.csproj" -c Release -o /app/publish

# Stage 2: Run
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SmartDevicesStore.API.dll"]