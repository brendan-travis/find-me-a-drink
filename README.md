# Find Me A Drink 🍺

Fancy a drink but don't know where to go?

This application can help with that by searching across a database of Leeds' finest tap rooms.

The application features a Vue frontend, utilising Vite for a quick build environment and Tailwind for a modular approach to CSS. The API uses a .NET 6 Web API wrapping a PostgreSQL database.

The project also features a number of infrastructure scripts to spin the whole application up at once in a containerized environment.

## Prerequisites

- .NET 6
- Docker & Kubernetes (Docker Desktop)
- Node & NPM

## Running The Application

### Running everything

Use the `./start.sh` script to run all the setup scripts to launch the kubernetes hosted backend and the Vue frontend.

When finished, use the `./stop.sh` script to clean up all of the created resources.

## Infrastructure

The application is split into 2 main parts. The frontend, meant to sit as a static site in your host of choice. And the backend, hosted in a kubernetes cluster.

![Infrastructure](/assets/infrastructure.png)

The kubernetes cluster has 3 main components, the ingress controller, the .NET web API and the PostgreSQL database.

The ingress controller is set up with a single ingress rule to forward all traffic to the .NET API with an internal connection. The ingress controller is exposed via NodePort and is the only way to access the API from outside the cluster.

The API speaks to the database in a similar manner, using the private, internal connection to connect via the private database service. The database does have a public service to allow for debugging/management from outside the cluster.

The database does not make use of any volume mounts and so the data is ephemeral and will need to be repopulated, should the pod restart.

The following ports are exposed from the cluster:

- 30200 - Ingress Controller http
- 30201 - Ingress Controller https
- 30202 - PostgreSQL DB public access

## License

This application is licensed under the [MIT license](https://opensource.org/licenses/MIT).
