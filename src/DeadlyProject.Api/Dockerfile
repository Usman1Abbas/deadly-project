FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/DeadlyProject.Api/DeadlyProject.Api.csproj", "src/DeadlyProject.Api/"]
RUN dotnet restore "src/DeadlyProject.Api/DeadlyProject.Api.csproj"
COPY . .
WORKDIR "/src/src/DeadlyProject.Api"
RUN dotnet build "DeadlyProject.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DeadlyProject.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DeadlyProject.Api.dll"]