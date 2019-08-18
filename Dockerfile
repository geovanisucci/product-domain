FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["src/ProductBoundedContext.Service/ProductBoundedContext.Service.csproj", "ProductBoundedContext.Service/"]
RUN dotnet restore "ProductBoundedContext.Service/ProductBoundedContext.Service.csproj"
COPY  ./src .
WORKDIR /src/ProductBoundedContext.Service
RUN dotnet build "ProductBoundedContext.Service.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ProductBoundedContext.Service.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ProductBoundedContext.Service.dll"]
