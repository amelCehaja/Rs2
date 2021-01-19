FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-buster AS build
WORKDIR /src
COPY . .

FROM build AS publish
RUN dotnet publish "WebAPI" -c Release -o /app
FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ADD /Slike SlikeSeed/

ENTRYPOINT ["dotnet", "WebAPI.dll"]