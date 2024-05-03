#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Zalex.HR.Certificates/Zalex.HR.Certificates.Api.csproj", "Zalex.HR.Certificates/"]
COPY ["Zalex.HR.Certificates.Dal/Zalex.HR.Certificates.Dal.csproj", "Zalex.HR.Certificates.Dal/"]
RUN dotnet restore "Zalex.HR.Certificates/Zalex.HR.Certificates.Api.csproj"
COPY . .
WORKDIR "/src/Zalex.HR.Certificates"
RUN dotnet build "Zalex.HR.Certificates.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Debug
RUN dotnet publish "Zalex.HR.Certificates.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Zalex.HR.Certificates.Api.dll"]

