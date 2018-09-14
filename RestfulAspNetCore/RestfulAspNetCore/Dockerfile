FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY RestfulAspNetCore/RestfulAspNetCore.Services.csproj RestfulAspNetCore/
COPY RestfulAspNetCore.Application/RestfulAspNetCore.Application.csproj RestfulAspNetCore.Application/
COPY RestfulAspNetCore.Domain/RestfulAspNetCore.Domain.csproj RestfulAspNetCore.Domain/
COPY RestfulAspNetCore.Helper/RestfulAspNetCore.Helper.csproj RestfulAspNetCore.Helper/
COPY RestfulAspNetCore.Data/RestfulAspNetCore.Data.csproj RestfulAspNetCore.Data/
RUN dotnet restore RestfulAspNetCore/RestfulAspNetCore.Services.csproj
COPY . .
WORKDIR /src/RestfulAspNetCore
RUN dotnet build RestfulAspNetCore.Services.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish RestfulAspNetCore.Services.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "RestfulAspNetCore.Services.dll"]
