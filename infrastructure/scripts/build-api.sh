#!/bin/bash
parent_path=$( cd "$(dirname "${BASH_SOURCE[0]}")" ; pwd -P )
cd "$parent_path"

docker start registry || docker run -d -p 5000:5000 --restart=always --name registry registry:2

cd ../../api/
docker build -t localhost:5000/find-me-a-drink-api:1.0 .
docker push localhost:5000/find-me-a-drink-api:1.0
