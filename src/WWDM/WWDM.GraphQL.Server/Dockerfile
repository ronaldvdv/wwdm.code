FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["WWDM.GraphQL.Server/WWDM.GraphQL.Server.csproj", "WWDM.GraphQL.Server/"]
COPY ["WWDM.Data/WWDM.Data.csproj", "WWDM.Data/"]
COPY ["WWDM.Util/WWDM.Util.csproj", "WWDM.Util/"]
COPY ["WWDM.GraphQL.Schema/WWDM.GraphQL.Schema.csproj", "WWDM.GraphQL.Schema/"]
COPY ["WWDM.Infrastructure/WWDM.Infrastructure.csproj", "WWDM.Infrastructure/"]
RUN dotnet restore "WWDM.GraphQL.Server/WWDM.GraphQL.Server.csproj"
COPY . .
WORKDIR "/src/WWDM.GraphQL.Server"
RUN dotnet build "WWDM.GraphQL.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WWDM.GraphQL.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WWDM.GraphQL.Server.dll"]