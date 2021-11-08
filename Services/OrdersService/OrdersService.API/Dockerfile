FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["../Services/OrdersService/OrdersService.API/OrdersService.API.csproj", "OrdersService.API/"]
RUN dotnet restore "../Services/OrdersService/OrdersService.API/OrdersService.API.csproj"
COPY . .
WORKDIR "/src/OrdersService.API"
RUN dotnet build "OrdersService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OrdersService.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrdersService.API.dll"]
