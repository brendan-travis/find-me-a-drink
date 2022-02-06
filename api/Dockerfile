FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
COPY . .
RUN dotnet build FindMeADrink.API.sln
RUN dotnet publish src/Presentation/Presentation.csproj -c Release -o out

FROM base AS final
COPY --from=build /out .
ENTRYPOINT ["dotnet", "Presentation.dll"]
