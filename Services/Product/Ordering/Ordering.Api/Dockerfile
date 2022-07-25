#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Product/Ordering/Ordering.Api/Ordering.Api.csproj", "Services/Product/Ordering/Ordering.Api/"]
COPY ["Services/Product/Ordering/Ordering.Applicaion/Ordering.Applicaion.csproj", "Services/Product/Ordering/Ordering.Applicaion/"]
COPY ["Services/Product/Ordering/Ordering.Domain/Ordering.Domain.csproj", "Services/Product/Ordering/Ordering.Domain/"]
COPY ["BuildingBlocks/EventBus.Message/EventBus.Message.csproj", "BuildingBlocks/EventBus.Message/"]
RUN dotnet restore "Services/Product/Ordering/Ordering.Api/Ordering.Api.csproj"
COPY . .
WORKDIR "/src/Services/Product/Ordering/Ordering.Api"
RUN dotnet build "Ordering.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ordering.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ordering.Api.dll"]