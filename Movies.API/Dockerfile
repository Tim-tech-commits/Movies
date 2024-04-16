#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy csproj and restore 
COPY *.csproj ./
RUN dotnet restore
RUN ls -la /app/out && bash
# Copy the remaining files and build the application
COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy the published output from the build stage
COPY --from=build-env /app/out .

# Copy the JSON data file from the Data folder into the image
COPY Data/Movies.json ./Data/

EXPOSE 80

ENTRYPOINT ["dotnet", "Movies.API.dll"]

