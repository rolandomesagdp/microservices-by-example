# microservices-by-example

Shows how to implement a microservices architecture with docker containers.
Uses containers for Asp.Net Core API and Angular Apps
Uses Dockerfile inside the .Net Core api project to generate the container image for this service.
Uses a Dockerfile inside angular project to generate the container image for the app.
Uses a compose.yml file to orchestrate the deployment of both the asp.net core api and the angular app as container services
when deployed, the angular app communicates with the api.
