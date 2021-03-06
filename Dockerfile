#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1.17-focal AS base
ENV ASPNETCORE_URLS=http://+:5000
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY NuGet.Config .
COPY ["src/HelloWorld.Web/HelloWorld.Web.csproj", "HelloWorld.Web/"]
RUN dotnet restore "HelloWorld.Web/HelloWorld.Web.csproj"
COPY /src /src
WORKDIR "/src/HelloWorld.Web"
RUN dotnet build "HelloWorld.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HelloWorld.Web.csproj" -c Release -o /app/publish

FROM base AS final
RUN useradd nonroot -m
USER nonroot
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HelloWorld.Web.dll"]
