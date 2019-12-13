FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build-env
WORKDIR /app

COPY src/Discount.API/*.csproj ./
RUN dotnet restore

COPY src/Discount.API/. ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Discount.API.dll"]