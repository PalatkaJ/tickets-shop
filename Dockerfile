FROM mcr.microsoft.com/dotnet/runtime:9.0
WORKDIR /app
COPY publish/ .
ENTRYPOINT ["dotnet", "tickets-shop.UI.dll"]
