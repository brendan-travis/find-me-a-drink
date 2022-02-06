#!/bin/bash
parent_path=$( cd "$(dirname "${BASH_SOURCE[0]}")" ; pwd -P )
cd "$parent_path"

kubectl apply -f ../manifests/namespace.yaml
kubectl apply -f ../manifests/postgres.yaml
