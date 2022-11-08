#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/RepCrime.MVC/RepCrime.MVC.csproj", "src/RepCrime.MVC/"]
COPY ["src/RepCrime.Common/RepCrime.Common.csproj", "src/RepCrime.Common/"]
RUN dotnet restore "src/RepCrime.MVC/RepCrime.MVC.csproj"
COPY . .
WORKDIR "/src/src/RepCrime.MVC"
RUN dotnet build "RepCrime.MVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RepCrime.MVC.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RepCrime.MVC.dll"]