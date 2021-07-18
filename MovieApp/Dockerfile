FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base
WORKDIR /app
EXPOSE 5000

ENV ASPNETCORE_URLS=http://+:5000

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["MovieApp.csproj", "./"]
RUN dotnet restore "MovieApp.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "MovieApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MovieApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN dotnet dev-certs https --trust
ENTRYPOINT ["dotnet", "MovieApp.dll"]
