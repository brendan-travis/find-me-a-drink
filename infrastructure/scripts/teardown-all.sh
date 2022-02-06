#!/bin/bash
parent_path=$( cd "$(dirname "${BASH_SOURCE[0]}")" ; pwd -P )
cd "$parent_path"

kubectl delete -f ../manifests/api.yaml
kubectl delete -f ../manifests/ingress.yaml
kubectl delete -f ../manifests/ingress-controller.yaml
kubectl delete -f ../manifests/postgres.yaml
kubectl delete -f ../manifests/namespace.yaml

docker stop registry
docker rm registry
