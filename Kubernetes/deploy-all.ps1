  
echo "====================="
echo "====== deploy ======"
echo "====================="

kubectl -n microservice apply -f .\sqlserver.yaml
kubectl -n microservice apply -f .\customer-api.yaml
kubectl -n microservice apply -f .\customer-web.yaml