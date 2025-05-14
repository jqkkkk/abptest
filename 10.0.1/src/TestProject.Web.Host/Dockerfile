FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["src/TestProject.Web.Host/TestProject.Web.Host.csproj", "src/TestProject.Web.Host/"]
COPY ["src/TestProject.Web.Core/TestProject.Web.Core.csproj", "src/TestProject.Web.Core/"]
COPY ["src/TestProject.Application/TestProject.Application.csproj", "src/TestProject.Application/"]
COPY ["src/TestProject.Core/TestProject.Core.csproj", "src/TestProject.Core/"]
COPY ["src/TestProject.EntityFrameworkCore/TestProject.EntityFrameworkCore.csproj", "src/TestProject.EntityFrameworkCore/"]
WORKDIR "/src/src/TestProject.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/TestProject.Web.Host", "src/TestProject.Web.Host"]
COPY ["src/TestProject.Web.Core", "src/TestProject.Web.Core"]
COPY ["src/TestProject.Application", "src/TestProject.Application"]
COPY ["src/TestProject.Core", "src/TestProject.Core"]
COPY ["src/TestProject.EntityFrameworkCore", "src/TestProject.EntityFrameworkCore"]
WORKDIR "/src/src/TestProject.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "TestProject.Web.Host.dll"]
