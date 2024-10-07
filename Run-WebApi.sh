#!/bin/bash

echo "Restoring NuGet packages for the entire solution..."
dotnet restore

echo "Building the entire solution..."
dotnet build --no-restore

echo Setting ENVIRONMENT to Development...
export ASPNETCORE_ENVIRONMENT=Development

echo "Running the Web API project..."
dotnet run --project Apexa.TechnicalAssignment.AdvisorApp.WebAPI/Apexa.TechnicalAssignment.AdvisorApp.WebAPI.csproj