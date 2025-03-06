# KubernetesDeploymentDemo
Playground project demonstrating docker compose and kubernetes deployment of multiple services in a basic scenario

# Build
![.NET](https://github.com/a-legotin/KubernetesDeploymentDemo/workflows/.NET/badge.svg?branch=master)

# Service diagram

![Diagram](https://github.com/a-legotin/KubernetesDeploymentDemo/blob/master/assets/service-diagram.svg)


# Description

**ngninx**- reverse proxy

**web app** - web page to show service data (latest orders and a bit of statistics)

**catalog** - service handling catalog items

**orders** - service handling orders created by customers

**customers** - service handling customers

**order service** - generates dummy orders from pre-populated data

# Run

To build docker image use docker compose

`docker-compose build`

Now test services with docker compose

`docker-compose up -d`

### or

use kubernetes and deploy everything with yaml files from `deploy` folder