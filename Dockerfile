# Use the official .NET 6 runtime as a base image
FROM mcr.microsoft.com/dotnet/sdk:7.0

# Set the working directory in the container
WORKDIR /app
# Copy the published C# GraphQL application to the container
COPY ./bin/Release/net7.0/publish /app
# Expose port 5000 to allow external access
EXPOSE 5000
# Define the entry point for your application

CMD ["dotnet","GraphqlAPI.dll"]