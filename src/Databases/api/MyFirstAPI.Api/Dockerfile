FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY MyFirstAPI.Api/MyFirstAPI.Api.csproj MyFirstAPI.Api/
COPY MyFirstAPI.Domain/MyFirstAPI.Domain.csproj MyFirstAPI.Domain/
COPY MyFirstAPI.Application/MyFirstAPI.Application.csproj MyFirstAPI.Application/
COPY MyFirstAPI.Infrastructure/MyFirstAPI.Infrastructure.csproj MyFirstAPI.Infrastructure/
RUN dotnet restore MyFirstAPI.Api/MyFirstAPI.Api.csproj
COPY . .
WORKDIR /src/MyFirstAPI.Api
RUN dotnet build MyFirstAPI.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish MyFirstAPI.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MyFirstAPI.Api.dll"]
