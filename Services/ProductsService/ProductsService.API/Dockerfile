FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["../Services/ProductsService/ProductsService.API/ProductsService.API.csproj", "ProductsService.API/"]
RUN dotnet restore "../Services/ProductsService/ProductsService.API/ProductsService.API.csproj"
COPY . .
WORKDIR "/src/ProductsService.API"
RUN dotnet build "ProductsService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProductsService.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductsService.API.dll"]
