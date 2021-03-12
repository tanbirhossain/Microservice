#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
#EXPOSE 80
#EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Customer.WEB/Customer.WEB.csproj", "Customer.WEB/"]
RUN dotnet restore "Customer.WEB/Customer.WEB.csproj"
COPY . .
WORKDIR "/src/Customer.WEB"
RUN dotnet build "Customer.WEB.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Customer.WEB.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Expose ports
#EXPOSE 6100/tcp
#EXPOSE 6100
#ENV ASPNETCORE_URLS="http://*:6100"

ENTRYPOINT ["dotnet", "Customer.WEB.dll"]


# inline command

## Build Image 
# docker build -t customerweb:v1 . -f Customer.WEB/Dockerfile  

## Create Cluster
# docker run -p 32702:80 -p 32703:443 customerweb:v1
