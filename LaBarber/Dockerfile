FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["LaBarber/LaBarber.API.csproj", "LaBarber/"]
RUN dotnet restore "LaBarber/LaBarber.API.csproj"
ARG BUILD_CONFIGURATION=Release
COPY . .
WORKDIR "/src/LaBarber"
RUN dotnet build "LaBarber.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LaBarber.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LaBarber.API.dll"]