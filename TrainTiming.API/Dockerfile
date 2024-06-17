FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TrainTiming.API/TrainTiming.API.csproj", "TrainTiming.API/"]
COPY ["TrainTiming.Application/TrainTiming.Application.csproj", "TrainTiming.Application/"]
COPY ["TrainTiming.Core/TrainTiming.Core.csproj", "TrainTiming.Core/"]
COPY ["TrainTiming.Persistence/TrainTiming.Persistence.csproj", "TrainTiming.Persistence/"]
RUN dotnet restore "TrainTiming.API/TrainTiming.API.csproj"
COPY . .
WORKDIR "/src/TrainTiming.API"
RUN dotnet build "TrainTiming.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "TrainTiming.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TrainTiming.API.dll"]
