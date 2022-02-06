#!/bin/bash
./infrastructure/scripts/build-api.sh
./infrastructure/scripts/deploy-api.sh
./infrastructure/scripts/deploy-ingress.sh
./infrastructure/scripts/deploy-db.sh
./infrastructure/scripts/populate-db.sh
./infrastructure/scripts/launch-ui.sh
