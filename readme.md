cd order.api
dapr run --app-id order-api --app-port 5267 --dapr-http-port 3500 -- dotnet run
cd product.api
dapr run --app-id product-api --app-port 5037 --dapr-http-port 3500 -- dotnet run