#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/RepCrime.LawEnforcement.API/RepCrime.LawEnforcement.API.csproj", "src/RepCrime.LawEnforcement.API/"]
COPY ["src/RepCrime.Common/RepCrime.Common.csproj", "src/RepCrime.Common/"]
COPY ["src/RepCrime.LawEnforcement.DATA/RepCrime.LawEnforcement.DATA.csproj", "src/RepCrime.LawEnforcement.DATA/"]
RUN dotnet restore "src/RepCrime.LawEnforcement.API/RepCrime.LawEnforcement.API.csproj"
COPY . .
WORKDIR "/src/src/RepCrime.LawEnforcement.API"
RUN dotnet build "RepCrime.LawEnforcement.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RepCrime.LawEnforcement.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RepCrime.LawEnforcement.API.dll"]