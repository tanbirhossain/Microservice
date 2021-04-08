
echo "====================="
echo "====== deploy ======="
echo "====================="
kubectl create namespace microservice 
kubectl -n microservice apply -f .\deployment\sqlserver.yaml
kubectl -n microservice apply -f .\deployment\customer-api.yaml
kubectl -n microservice apply -f .\deployment\customer-web.yaml

