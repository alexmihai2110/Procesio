FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app


FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Procesio.csproj", "./"]
RUN dotnet restore "./Procesio.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "Procesio.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "Procesio.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "Procesio.dll"]