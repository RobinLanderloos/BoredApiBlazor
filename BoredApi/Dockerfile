#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY "BoredApi.csproj" .
RUN dotnet restore "BoredApi.csproj"
COPY . .
RUN dotnet build "BoredApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BoredApi.csproj" -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY nginx.conf /etc/nginx/nginx.conf