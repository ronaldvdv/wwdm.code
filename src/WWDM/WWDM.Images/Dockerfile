FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["WWDM.Images/WWDM.Images.csproj", "WWDM.Images/"]
COPY ["WWDM.Data/WWDM.Data.csproj", "WWDM.Data/"]
COPY ["WWDM.Util/WWDM.Util.csproj", "WWDM.Util/"]
COPY ["WWDM.Infrastructure/WWDM.Infrastructure.csproj", "WWDM.Infrastructure/"]
RUN dotnet restore "WWDM.Images/WWDM.Images.csproj"
COPY . .
WORKDIR "/src/WWDM.Images"
RUN dotnet build "WWDM.Images.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WWDM.Images.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WWDM.Images.dll"]