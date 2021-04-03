kubectl -n microservice apply -f .\kubernetes\sqlserver.yaml
kubectl -n microservice apply -f .\kubernetes\customer-api.yaml
kubectl -n microservice apply -f .\kubernetes\customer-web.yaml