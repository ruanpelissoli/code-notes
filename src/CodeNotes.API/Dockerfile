#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/CodeNotes.API/CodeNotes.API.csproj", "src/CodeNotes.API/"]
COPY ["CodeNotes.Domain/CodeNotes.Domain.csproj", "CodeNotes.Domain/"]
COPY ["src/CodeNotes.Infrastructure/CodeNotes.Infrastructure.csproj", "src/CodeNotes.Infrastructure/"]
RUN dotnet restore "src/CodeNotes.API/CodeNotes.API.csproj"
COPY . .
WORKDIR "/src/src/CodeNotes.API"
RUN dotnet build "CodeNotes.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CodeNotes.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CodeNotes.API.dll"]