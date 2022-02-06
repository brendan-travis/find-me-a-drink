#!/bin/bash
parent_path=$( cd "$(dirname "${BASH_SOURCE[0]}")" ; pwd -P )
cd "$parent_path"

while [[ $(kubectl get pods -n drink -l app=database -o 'jsonpath={..status.conditions[?(@.type=="Ready")].status}') != "True" ]]; do echo "waiting for DB pod to be ready" && sleep 5; done
sleep 5;

PGPASSWORD=SecretPassword123 psql -U postgres -d postgres -p 30202 -f ../data/create-table.sql
PGPASSWORD=SecretPassword123 psql -U postgres -d postgres -p 30202 -c "\copy locations FROM '../data/leedsbeerquest.csv' DELIMITER ',' ENCODING 'UTF8' CSV HEADER;"
