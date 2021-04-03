kubectl delete deploy customer-web-deployment -n microservice
kubectl delete deploy customer-api-deployment -n microservice
kubectl delete deploy sqlserver-deployment -n microservice

kubectl delete service sqlserver-service -n microservice
kubectl delete service customer-api-service -n microservice
kubectl delete service customer-web-service -n microservice