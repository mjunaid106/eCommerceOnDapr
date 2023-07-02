# Order API

> cd order.api

> dapr run --app-id order-api --app-port 5267 --dapr-http-port 3500 -- dotnet run

To run using solution wide config use

> dapr run --app-id order-api --resources-path ../components/ --app-port 5267 --dapr-http-port 3500 -- dotnet run

# Product API
> cd product.api

> dapr run --app-id product-api --app-port 5037 --dapr-http-port 3501 -- dotnet run

To run using solution wide config use

> dapr run --app-id product-api --resources-path ../components/ --app-port 5037 --dapr-http-port 3501 -- dotnet run