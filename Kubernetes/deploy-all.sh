kubectl -n microservice apply -f .\deploy-sqlserver.yaml
kubectl -n microservice apply -f .\deploy-customer-api.yaml
kubectl -n microservice apply -f .\deploy-customer-web.yaml
