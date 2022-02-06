#!/bin/bash
parent_path=$( cd "$(dirname "${BASH_SOURCE[0]}")" ; pwd -P )
cd "$parent_path"

kubectl apply -f ../manifests/ingress.yaml
kubectl apply -f ../manifests/ingress-controller.yaml
