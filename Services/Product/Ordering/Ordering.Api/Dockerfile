#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80


FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Ordering.Api/Ordering.Api.csproj", "Ordering.Api/"]
COPY ["Ordering.Applicaion/Ordering.Applicaion.csproj", "Ordering.Applicaion/"]
COPY ["Ordering.Domain/Ordering.Domain.csproj", "Ordering.Domain/"]
COPY ["EventBus.Message/EventBus.Message.csproj", "EventBus.Message/"]
RUN dotnet restore "Ordering.Api/Ordering.Api.csproj"
COPY . .
WORKDIR "/src/Ordering.Api"
RUN dotnet build "Ordering.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ordering.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ordering.Api.dll"]