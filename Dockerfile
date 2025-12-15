# Dockerfile
FROM mcr.microsoft.com/dotnet/sdk:9.0
WORKDIR /tickets-shop

COPY . .

ENTRYPOINT ["dotnet", "run", "--project", "src/tickets-shop.UI"]
