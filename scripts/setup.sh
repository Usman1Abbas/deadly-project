#!/bin/bash

# Install .NET dependencies
dotnet restore src/DeadlyProject.Api/DeadlyProject.Api.csproj

# Install client dependencies
cd src/DeadlyProject.Client
npm install
cd ../..
