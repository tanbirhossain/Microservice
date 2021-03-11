#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
#EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Customer.API/Customer.API.csproj", "Customer.API/"]
RUN dotnet restore "Customer.API/Customer.API.csproj"
COPY . .
WORKDIR "/src/Customer.API"
RUN dotnet build "Customer.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Customer.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

## Expose ports
#EXPOSE 5100/tcp
#ENV ASPNETCORE_URLS http://*:5100

ENTRYPOINT ["dotnet", "Customer.API.dll"]



# inline command

## Build Image 
# docker build -t customerapi:v1 . -f Customer.API/Dockerfile  

## Create Cluster
# docker run -p 32789:80 customerapi:v1
