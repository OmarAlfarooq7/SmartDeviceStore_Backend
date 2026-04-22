# المرحلة الأولى: البناء
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# نسخ ملف المشروع من داخل المجلد الفرعي
COPY ["SmartDevicesStore.API/SmartDevicesStore.API.csproj", "SmartDevicesStore.API/"]
RUN dotnet restore "SmartDevicesStore.API/SmartDevicesStore.API.csproj"

# نسخ كل الملفات وبناء المشروع
COPY . .
WORKDIR "/src/SmartDevicesStore.API"
RUN dotnet publish "SmartDevicesStore.API.csproj" -c Release -o /app/publish

# المرحلة الثانية: التشغيل
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SmartDevicesStore.API.dll"]