FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["../Services/CustomersService/CustomersService.API/CustomersService.API.csproj", "CustomersService.API/"]
RUN dotnet restore "../Services/CustomersService/CustomersService.API/CustomersService.API.csproj"
COPY . .
WORKDIR "/src/CustomersService.API"
RUN dotnet build "CustomersService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CustomersService.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CustomersService.API.dll"]
