##$See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
#
##Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
##For more information, please see https://aka.ms/containercompat
##
#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#WORKDIR /src
#COPY ["PruebaTecnica/PruebaTecnica.csproj", "PruebaTecnica/"]
#RUN dotnet restore "PruebaTecnica/PruebaTecnica.csproj"
#COPY . .
#WORKDIR "/src/PruebaTecnica"
#RUN dotnet build "PruebaTecnica.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "PruebaTecnica.csproj" -c Release -o /app/publish /p:UseAppHost=false
#
#ENV REDISHOST=172.17.0.3
#ENV REDISPORT=6379
#
#EXPOSE 5000
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "PruebaTecnica.dll"]
#


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
MAINTAINER Santiago Guzman Rodriguez "santiagoguz15@gmail.com"

ARG BUILDCONFIG=RELEASE
ARG VERSION=1.0.0

WORKDIR /build
COPY *.csproj ./

RUN dotnet restore

COPY . ./

RUN dotnet publish -c $BUILDCONFIG -o out

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/sdk:6.0

MAINTAINER Santiago Guzman Rodriguez "santiagoguz15@gmail.com"

ENV REDISHOST=172.17.0.3
ENV REDISPORT=6379

EXPOSE 5000

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app

ENTRYPOINT ["dotnet", "PruebaTecnica.dll"]

