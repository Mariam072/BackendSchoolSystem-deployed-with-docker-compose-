# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BackendSchoolSystem.csproj", "."]
RUN dotnet restore "./BackendSchoolSystem.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./BackendSchoolSystem.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BackendSchoolSystem.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# 🔥 الحل: انسخ الـ Migrations مع الـ app
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
# انسخ مجلد الـ Migrations لو موجود
COPY --from=build /src/Migrations ./Migrations

ENTRYPOINT ["dotnet", "BackendSchoolSystem.dll"]