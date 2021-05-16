#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Stage : BASE
#FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
#WORKDIR /app

#Stage : BUILD
#FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#COPY "trivia-api/trivia-api.csproj" /app
#RUN dotnet restore "/app/trivia-api.csproj"

#Stage : BUILD
#WORKDIR /app
#RUN dotnet build "/app/trivia-api.csproj" -c Release -o /app/build


#FROM build AS publish
#WORKDIR /app/build
#RUN dotnet publish "/app/build/trivia-api.csproj" -c Release -o /app/publish


#FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS runtime
#WORKDIR /app/publish
#COPY --from=publish /app/publish ./
#ENTRYPOINT ["dotnet", "trivia-api.dll"]


#FROM base AS final
#WORKDIR /app
#COPY --from=build /app/build .
#ENTRYPOINT ["dotnet", "bin/Release/netcoreapp3.1/trivia-api.dll"]


### VERSION 2 ####
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Stage : BASE
#FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
#WORKDIR /app

#Stage : BUILD
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /build
EXPOSE 80
EXPOSE 443
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app

#Stage : FINAL
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS final
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "trivia-api.dll"]