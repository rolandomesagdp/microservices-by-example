# microservices-by-example

Shows how to implement a microservices architecture with docker containers.
Uses containers for Asp.Net Core API and Angular Apps
Uses Dockerfile and dockerignore inside the .Net Core api project to generate the container image for this service.
Uses a Dockerfile and dockerignore inside angular project to generate the container image for the app.
Uses a root level compose.yml file to orchestrate the deployment of both the asp.net core api and the angular app as container services using Docker Compose tool.
when deployed, the angular app communicates with the api.

## Make it work

You should have Docker and Docker Compose installed
1- Clone the repository.
2- Open a CMD at this level (where the compose.yml file is).
3- Run the command: docker compose up -d
4- Go to <http://localhost:4021>: You should see an angular app with the following message printed on the screen:

# "Weather forecast registries count: 5"
