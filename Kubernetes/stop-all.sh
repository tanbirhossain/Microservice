kubectl delete svc --all -n microservice
kubectl delete deploy --all -n microservice
kubectl delete pods --all -n microservice
kubectl delete statefulsets --all -n microservice

kubectl delete pvc --all -n microservice
kubectl delete pv --all -n microservice
