  kubectl -n microservice apply -f .\kubernates\customer-web.yaml
  kubectl -n microservice apply -f .\kubernates\customer-api.yaml
  kubectl -n microservice apply -f .\kubernates\sqlserver.yaml