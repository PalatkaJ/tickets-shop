rm -rf publish
dotnet publish src/tickets-shop.UI/tickets-shop.UI.csproj -c Release -o publish

docker build -t simple-tickets-app .

touch app.db

docker run --rm -it -v "$(pwd)/app.db:/app/app.db" simple-tickets-app
